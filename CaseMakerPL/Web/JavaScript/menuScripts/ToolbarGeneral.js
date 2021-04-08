// JScript File

myGeneralToolConstants=function()
{
    this.newGeneral="newGeneral";
}



function myGeneral()
{
    this.Constants=new myGeneralToolConstants();
    this.newGeneral=new Action(this.Constants.newGeneral);
    
    this.SelectNew=function()
    {
        this.newGeneral.canExecute=true;
    };
    
    
    this.Init=function()
    {
        var act= this.Actions;
        var c=this.Constants;
        act[c.newGeneral]=this.newGeneral;
    }
    
}




myGeneral.prototype= new ActionGroup('General');
TOOLBAR.General= new myGeneral();
TOOLBAR.General.Init();

TOOLBAR.General.isVisible=true;
TOOLBAR.General.newGeneral.canExecute=true;
