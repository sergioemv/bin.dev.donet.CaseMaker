// 

myElementConstants=function()
{
    this.newElement="newElement";
    this.copyElement="copyElement"
    this.cutElement="cutElement";
}



function myElements()
{
    this.Constants=new myElementConstants();
    this.newElement=new Action(this.Constants.newElement);
    
    
    this.SelectElement=function()
    {
        this.newElement.canExecute=true;
        TOOLBAR.General.newGeneral.canExecute=false;
    };
    
    
    this.Init=function()
    {
        var act= this.Actions;
        var c=this.Constants;
        act[c.newElement]=this.newElement;
    }
    
}




myElements.prototype= new ActionGroup('Elements');
TOOLBAR.Elements= new myElements();
TOOLBAR.Elements.Init();