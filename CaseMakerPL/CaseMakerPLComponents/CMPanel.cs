using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using ASP = System.Web.UI.WebControls;

namespace CaseMakerPlComponents.Panel
{
    [ToolboxBitmap(typeof (System.Web.UI.WebControls.Panel))]
    public class CMPanel : System.Web.UI.WebControls.Panel
    {
        #region Override methods

        /// <summary>
        /// Renders the component with custom javascript objects.
        /// </summary>
        /// <param name="writer">HtmlTextWriter</param>
        protected override void Render(HtmlTextWriter writer)
        {
            //will render only if the component is visible.
            if (Visible)
            {
                DefaultSetting();
                RenderJavaScript(writer);

                base.Render(writer);

                if (hasSilverlight())
                    writer.Write(getHeadSilverlightContainer());
                ;
                if (hasSilverlight())
                    writer.Write("</div>");
                if (hasSilverlight())
                    writeSilverLightContent(writer);
            }
        }

        #endregion

        #region JavaScript Methods

        /// <summary>
        /// Write javascript begin tag.
        /// </summary>
        /// <returns>javascript begin tag.</returns>
        private String getBeginTagScript()
        {
            return "<script language='javascript' type='text/javascript'>";
        }

        /// <summary>
        /// Write javascript end tag.
        /// </summary>
        /// <returns></returns>
        private String getEndTagScript()
        {
            return "</script>";
        }


        /// <summary>
        /// Obtain the dynamic name of the javascrip class, that will control the show, hide,and modal.
        /// </summary>
        /// <returns>Name of the class</returns>
        private String getJavaScriptClass()
        {
            return ClientID + "Class";
        }

        /// <summary>
        /// Obtain the dynamic name of the javascrip object, that will control the show, hide,and modal.
        /// <see cref="getJavaScriptClass"/>
        /// </summary>
        /// <returns>Name of the object</returns>
        public String getJavaScriptObject()
        {
            return ClientID + "Obj";
        }

        /// <summary>
        /// Obtain the dynamic name of the html div tag who will contain the silverlight plug-in.
        /// </summary>
        /// <returns>Name of a div host of silverlight(dynamically created) </returns>
        public String getSilverlightDivHostName()
        {
            return ClientID + "SilverHost";
        }

        /// <summary>
        ///  Obtain the ID of the silverlight plug-in.
        /// </summary>
        /// <returns>ID silverlight(dynamically created).</returns>
        private String getSilverlightControlName()
        {
            return ClientID + "Control";
        }

        /// <summary>
        /// Javascript Object name who will control the silverlight events.
        /// </summary>
        /// <returns>javascript Object.</returns>
        private String getSilverlightObjectName()
        {
            return ClientID + "SilverObj";
        }

        /// <summary>
        /// Javascript Class name who will control the silverlight events.
        /// </summary>
        /// <returns>javascript class name.</returns>
        private String getSilverlightJSClass()
        {
            return ClientID + "SilverObjClass";
        }

        /// <summary>
        /// Name of the javascript method who will create silverlight methods.
        /// </summary>
        /// <returns>Name of the javascript method.</returns>
        private String SilverlightMainFunction()
        {
            return "createSilverlight" + ClientID;
        }

        /// <summary>
        /// Javascript code to create a silverlight plug-in.
        /// </summary>
        /// <param name="__builder">StringBuilder to attach javascript code.</param>
        private void RenderSilverlightControl(StringBuilder __builder)
        {
            __builder.AppendLine("var " + getSilverlightObjectName() + ";");
            __builder.AppendLine("function " + SilverlightMainFunction() + "(){");
            __builder.AppendLine(getSilverlightObjectName() + " = new CMPanel." + getSilverlightJSClass() + "();");
            __builder.AppendLine("Silverlight.createObjectEx({");
            __builder.AppendLine("source: '" + this.XAMLFile + "',");
            __builder.AppendLine("parentElement: document.getElementById('" + getSilverlightDivHostName() + "'),");
            __builder.AppendLine("id: '" + getSilverlightControlName() + "',");
            __builder.AppendLine("properties: {");
            __builder.AppendLine("width: '" + widthContainer + "',");
            __builder.AppendLine("height: '" + heightContainer + "',");
            __builder.AppendLine("inplaceInstallPrompt:'false',");
            __builder.AppendLine("isWindowless:'true',");
            __builder.AppendLine("background:'transparent',");
            __builder.AppendLine("version: '1.1'");
            __builder.AppendLine("},");
            __builder.AppendLine("events: {");
            __builder.AppendLine("onLoad: Silverlight.createDelegate(" + getSilverlightObjectName() + ", " +
                                 getSilverlightObjectName() + ".handleLoad)");
            __builder.AppendLine("}");
            __builder.AppendLine("});");
            __builder.AppendLine("}");
            __builder.AppendLine("if (!window.Silverlight){ ");
            __builder.AppendLine("window.Silverlight = {};");
            __builder.AppendLine("}");
            __builder.AppendLine("if (!Silverlight.createDelegate)");
            __builder.AppendLine("Silverlight.createDelegate = function(instance, method) {");
            __builder.AppendLine("return function() {");
            __builder.AppendLine("return method.apply(instance, arguments);");
            __builder.AppendLine("}");
            __builder.AppendLine("}");
        }

        /// <summary>
        /// Javascript code to create a silverlight plug-in (auxiliar methods, create main functins).
        /// </summary>
        /// <param name="__builder">StringBuilder to attach javascript code.</param>
        private void RenderSilverlightHandler(StringBuilder __builder)
        {
            __builder.AppendLine("if (!window.CMPanel)");
            __builder.AppendLine("window.CMPanel = {};");
            __builder.AppendLine("CMPanel." + getSilverlightJSClass() + " = function(){}");
            __builder.AppendLine("CMPanel." + getSilverlightJSClass() + ".prototype ={");
            __builder.AppendLine("handleLoad: function(__control, __userContext, __rootElement){");
            __builder.AppendLine("this.rootElement = __rootElement;");
            __builder.AppendLine("this.originalOpacity = this.rootElement.opacity;");

            if (hiddenContainer)
                __builder.AppendLine("this.rootElement.opacity=0;"); //if the panel must begin hidden.

            if (hasBeginAnimation())
                __builder.AppendLine("this.rootElement.findName('" + XAMLBeginAnimationName +
                                     "').addEventListener('Completed', Silverlight.createDelegate(this, this.onBeginAnimationComplete));");

            if (hasEndAnimation()) //if  an animation is assigned, create a listener event for it finish.
                __builder.AppendLine("this.rootElement.findName('" + XAMLEndAnimationName +
                                     "').addEventListener('Completed', Silverlight.createDelegate(this, this.onEndAnimationComplete));");

            __builder.AppendLine("},");
            __builder.AppendLine("BeginAnimation: function(){");

            if (hasBeginAnimation())
                __builder.AppendLine("this.rootElement.findName('" + XAMLBeginAnimationName + "').Begin();");

            __builder.AppendLine("},");

            if (hasBeginAnimation())
            {
                __builder.AppendLine("onBeginAnimationComplete: function(){");
                __builder.Append("document.getElementById('" + this.ClientID + "').style.display='block';");
                __builder.AppendLine("},");
            }

            if (hasEndAnimation())
            {
                __builder.AppendLine("onEndAnimationComplete: function(){");
                __builder.Append("document.getElementById('" + getSilverlightDivHostName() + "').style.display='none';");
                __builder.AppendLine("},");
            }

            __builder.AppendLine("EndAnimation: function(){");

            if (hasEndAnimation())
                __builder.AppendLine("this.rootElement.findName('" + XAMLEndAnimationName + "').Begin();");

            __builder.AppendLine("}");
            __builder.AppendLine("}");
        }

        /// <summary>
        /// Attahch javascript code to show containers.
        /// </summary>
        /// <param name="__builder">StringBuilder to contain js code.</param>
        private void attachShowMethod(StringBuilder __builder)
        {
            String strMethod;
            if (CustomShow != "")
            {
                strMethod = CustomShow;
            }
            else
            {
                strMethod = "Show";
                __builder.Append("function Show(){");
                __builder.Append("document.getElementById('" + getSilverlightDivHostName() +
                                 "').style.display= 'block';");

                __builder.Append(getSilverlightObjectName() + ".rootElement.opacity = 1;");
                if (!hasBeginAnimation())
                    __builder.Append("document.getElementById('" + this.ClientID + "').style.display='block';");
                else
                {
                    __builder.Append("document.getElementById('" + getSilverlightDivHostName() +
                                     "').style.display='block';");
                    __builder.Append(getSilverlightObjectName() + ".BeginAnimation();");
                }
                __builder.Append("}");
            }
            __builder.AppendLine(getJavaScriptClass() + ".prototype.Show=" + strMethod + ";");
        }

        /// <summary>
        /// Attahch javascript code to hide containers.
        /// </summary>
        /// <param name="__builder">StringBuilder with js code to hide containers.</param>
        private void attachHide(StringBuilder __builder)
        {
            String strMethod;
            if (CustomHide != "")
            {
                strMethod = CustomHide;
            }
            else
            {
                strMethod = "Hide";
                __builder.Append("function Hide(){");
                __builder.Append("document.getElementById('" + this.ClientID + "').style.display='none';");
                if (hasEndAnimation())
                    __builder.Append(getSilverlightObjectName() + ".EndAnimation();");

                //
                //if (!hasEndAnimation())
                //  __builder.Append(getSilverlightObjectName() + ".rootElement.opacity = 0;");
                //__builder.Append(getSilverlightDivHostName() + ".style.display='none';");

                //Note: Attach default funtions!!!
                __builder.Append("}");
            }
            __builder.AppendLine(getJavaScriptClass() + ".prototype.Hide=" + strMethod + ";");
        }

        /// <summary>
        /// Attahch javascript code to show and modal containers.
        /// </summary>
        /// <param name="__builder">StringBuilder with js code to show and modal containers.</param>
        private void attachShowModalMethod(StringBuilder __builder)
        {
            String strMethod;
            if (CustomShowModal != "")
            {
                strMethod = CustomShowModal;
            }
            else
            {
                strMethod = "ShowModal";
                __builder.Append("function ShowModal(){");
                //TODO: Attach default funtions!!!
                __builder.Append("}");
            }
            __builder.AppendLine(getJavaScriptClass() + ".prototype.ShowModal=" + strMethod + ";");
        }

        /// <summary>
        /// Will render the necesary javascript, has or not a xaml file attached.
        /// Render the basic Javascript method to show, hide and modal.
        /// </summary>
        /// <param name="writer">HtmlTextWriter</param>
        private void RenderJavaScript(HtmlTextWriter writer)
        {
            //if (willRenderCustomClientEvents) {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(getBeginTagScript());
            builder.AppendLine("function " + getJavaScriptClass() + "(){}");
            attachShowMethod(builder);
            attachHide(builder);
            attachShowModalMethod(builder);
            builder.AppendLine("var " + getJavaScriptObject() + "= new " + getJavaScriptClass() + "();");
            builder.AppendLine(getEndTagScript());
            writer.Write(builder.ToString());
            //}
        }

        /// <summary>
        /// Write the silverliht div container.
        /// </summary>
        /// <returns>html component code.</returns>
        private String getHeadSilverlightContainer()
        {
            StringBuilder builder = new StringBuilder();

            String strTop = "";
            String strLeft = "";

            if (!String.IsNullOrEmpty(this.Style["top"]))
                strTop = "top:" + this.Style["top"] + ";";
            if (!String.IsNullOrEmpty(this.Style["left"]))
                strLeft = "left:" + this.Style["left"] + ";";

            builder.Append("<div ");
            builder.Append("ID='" + getSilverlightDivHostName() + "' style='height:" + Convert.ToString(heightContainer) +
                           ";position:absolute;width:" + Convert.ToString(widthContainer) + "px;z-index:0;" + strTop +
                           strLeft + "'");

            builder.Append(">");
            return builder.ToString();
        }

        /// <summary>
        /// Write the silverlight body.
        /// </summary>
        /// <param name="writer"></param>
        private void writeSilverLightContent(HtmlTextWriter writer)
        {
            writer.Write(getBeginTagScript());
            StringBuilder builder = new StringBuilder();

            RenderSilverlightControl(builder);
            RenderSilverlightHandler(builder);
            builder.Append(SilverlightMainFunction() + "();");
            if (hiddenContainer)
                builder.Append("document.getElementById('" + getSilverlightDivHostName() + "').style.display='none';");
            writer.Write(builder.ToString());
            //builder.Append(getSilverlightDivHostName() + "style.display:'none';");
            writer.Write(getEndTagScript());
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Set some the default settings
        /// </summary>
        private void DefaultSetting()
        {
            //special configurations if a xaml file is attached
            if (hasSilverlight())
            {
                this.Style["position"] = "absolute";
                if (this.Style["z-index"] == null)
                    this.Style["z-index"] = Convert.ToString((zIndex + 1));
                if (String.IsNullOrEmpty(this.Style["width"]))
                    this.Style["width"] = Convert.ToString((widthContainer)) + "px";
                if (String.IsNullOrEmpty(this.Style["height"]))
                    this.Style["height"] = Convert.ToString((heightContainer)) + "px";
                if (hiddenContainer)
                    this.Style["display"] = "none";
            }
        }

        /// <summary>
        /// Indicate if a silverlight file si relationed with the component.
        /// <strong>It don't check if the file really exists.</strong>
        /// </summary>
        /// <returns></returns>
        private bool hasSilverlight()
        {
            return (!String.IsNullOrEmpty(XAMLFile));
        }

        /// <summary>
        /// Indicate if a silverlight animation for the begin is assigned (when show elements).
        /// PRE: a silverlight file must be assigned.
        /// <see>hasSilverlight </see>
        /// </summary>
        /// <returns></returns>
        private bool hasBeginAnimation()
        {
            return (!String.IsNullOrEmpty(XAMLBeginAnimationName) && hasSilverlight());
        }

        /// <summary>
        /// Indicate if a silverlight animation for the end is assigned (when hide elements.).
        /// PRE: a silverlight file must be assigned.
        /// <see>hasSilverlight </see>
        /// </summary>
        /// <returns></returns>
        private bool hasEndAnimation()
        {
            return (!String.IsNullOrEmpty(XAMLEndAnimationName) && hasSilverlight());
        }

        #endregion

        #region Silverlight Settings

        [Category("Silverlight Settings")]
        [DefaultValue(false)]
        [Description("Begin the container in 'hidden'.")]
        public virtual bool hiddenContainer
        {
            get
            {
                object obj = ViewState["hiddenContainer"];
                if (obj == null)
                    return false;
                else
                    return (bool) obj;
            }
            set { ViewState["hiddenContainer"] = value; }
        }


        [Category("Silverlight Settings.CSS")]
        [DefaultValue(1)]
        [Description("Indicate the zIndex Container.")]
        public int zIndex
        {
            get
            {
                object obj = ViewState["zIndex"];
                if (obj == null)
                    return 1;
                else
                    return (int) obj;
            }
            set { ViewState["zIndex"] = value; }
        }

        [Category("Silverlight Settings.CSS")]
        [DefaultValue(100)]
        [Description("Indicate the width of the Container.")]
        public int widthContainer
        {
            get
            {
                object obj = ViewState["widthContainer"];
                if (obj == null)
                    return 100;
                else
                    return (int) obj;
            }
            set { ViewState["widthContainer"] = value; }
        }

        [Category("Silverlight Settings.CSS")]
        [DefaultValue(100)]
        [Description("Indicate the height of the Container.")]
        public int heightContainer
        {
            get
            {
                object obj = ViewState["heightContainer"];
                if (obj == null)
                    return 100;
                else
                    return (int) obj;
            }
            set { ViewState["heightContainer"] = value; }
        }

        [Category("Silverlight Settings")]
        [DefaultValue(true)]
        [Description("Indicate a silverlight background must be rendered.")]
        public virtual bool renderSilverlightBackground
        {
            get
            {
                object obj = ViewState["renderSilverlightBackground"];
                if (obj == null)
                    return true;
                else
                    return (bool) obj;
            }
            set { ViewState["renderSilverlightBackground"] = value; }
        }

        [Category("Silverlight Settings")]
        [DefaultValue("")]
        [Description("XAML file to render.")]
        public virtual String XAMLFile
        {
            get
            {
                object obj = ViewState["XAMLFile"];
                if (obj == null)
                    return "";
                else
                    return (String) obj;
            }
            set { ViewState["XAMLFile"] = value; }
        }

        [Category("Silverlight Settings")]
        [DefaultValue("")]
        [Description("Begin animation name.")]
        public virtual String XAMLBeginAnimationName
        {
            get
            {
                object obj = ViewState["XAMLBeginAnimationName"];
                if (obj == null)
                    return "";
                else
                    return (String) obj;
            }
            set { ViewState["XAMLBeginAnimationName"] = value; }
        }

        [Category("Silverlight Settings")]
        [DefaultValue("")]
        [Description("End animation name.")]
        public virtual String XAMLEndAnimationName
        {
            get
            {
                object obj = ViewState["XAMLEndAnimationName"];
                if (obj == null)
                    return "";
                else
                    return (String) obj;
            }
            set { ViewState["XAMLEndAnimationName"] = value; }
        }

        #endregion

        #region Settings

        //[Category("Settings")]
        //[DefaultValue(true)]
        //[Description("Indicate if client side events (custom or not must be rendered).")]
        //public virtual bool willRenderCustomClientEvents {
        //    get {
        //        object obj = ViewState["willRenderCustomClientEvents"];
        //        if (obj == null)
        //            return true;
        //        else
        //            return (bool)obj;
        //    }
        //    set {
        //        ViewState["willRenderCustomClientEvents"] = value;
        //    }
        //}

        #endregion

        #region CustomClientEvents

        [Category("CustomClientEvents")]
        [DefaultValue("")]
        [Description("To attach a client custom show method.")]
        public virtual String CustomShow
        {
            get
            {
                object obj = ViewState["CustomShow"];
                if (obj == null)
                    return "";
                else
                    return (String) obj;
            }
            set { ViewState["CustomShow"] = value; }
        }


        [Category("CustomClientEvents")]
        [DefaultValue("")]
        [Description("To attach a client custom hide method.")]
        public virtual String CustomHide
        {
            get
            {
                object obj = ViewState["CustomHide"];
                if (obj == null)
                    return "";
                else
                    return (String) obj;
            }
            set { ViewState["CustomHide"] = value; }
        }


        [Category("CustomClientEvents")]
        [DefaultValue("")]
        [Description("To attach a client custom show modal method.")]
        public virtual String CustomShowModal
        {
            get
            {
                object obj = ViewState["CustomShowModal"];
                if (obj == null)
                    return "";
                else
                    return (String) obj;
            }
            set { ViewState["CustomShowModal"] = value; }
        }

        #endregion
    } //end of class CMPanel
}