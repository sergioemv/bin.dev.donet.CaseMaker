using System.Collections.Generic;

namespace CaseMaker.Entities.Testcases
{
    public interface IElementsBean
    {
        IList<Element> Elements { get; set; }
        void AddElement(Element element);
        void RemoveElement(Element element);
        Element GetElementByName(string name);
    }
}