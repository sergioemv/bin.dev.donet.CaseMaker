<%@ Import namespace="bi.general.enumerates.main"%>
<%@ Import namespace="CaseMaker.Localization"%>
<%@ Import namespace="CaseMakerWebUtils.storeData"%>






















<%@ Application Language="C#" %>

<script RunAt="server">

        private void Application_Start(object sender, EventArgs e)
        {
            String strPath = Server.MapPath("~/Config.xml");
            StoraDataList data = StoraDataList.readXMLArchive(strPath);
            StaticObjects.getStoreData = data;
        }

        private void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        private void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        /// <summary>
        /// Code that runs when a new session is started
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Session_Start(object sender, EventArgs e)
        {
            //Instantiate the session data Class, who contains information about the CURRENT session. 
            SessionObjects.getSessionData.CurrentTheme = StaticObjects.getWCMConstants.getValue(eWCMConstants.theme);
        }

        private void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }


        private void Application_BeginRequest(Object sender, EventArgs args)
        {
            // For each request initialize the culture values with the
            // user language as specified by the browser.
            try
            {
                String strLanguageRequest = Request.UserLanguages[0];
                String strAcceptedLanguage;
                //TODO: Paulo, improve, modify code, search languages in a file 
                switch ((strLanguageRequest.Substring(0, 2)))
                {
                    case "es":
                        strAcceptedLanguage = "es-ES";
                        ResourceSettings.setLanguage(ResourceSettings.Language.Spanish);
                        break;
                    case "de":
                        strAcceptedLanguage = "de-DE";
                        ResourceSettings.setLanguage(ResourceSettings.Language.Deutsch);
                        break;
                    default:
                        strAcceptedLanguage = "en-US";
                        ResourceSettings.setLanguage(ResourceSettings.Language.English);
                        break;
                }


                //SessionObjects.getLanguageInfo.setLanguage(strAcceptedLAnguage);
            }
            catch (Exception)
            {
                //eat the exception
            }
        }


</script>

