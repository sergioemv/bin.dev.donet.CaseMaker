using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using CaseMaker.Entities.Testcases;
using ISNet.WebUI.WebGrid;

namespace bi.maskClasses.testCases.CMElementUIClass
{
    /// <summary>
    /// Autor: portiz
    /// Description: This class represents a collection that holds mask elements (CMElementsUI)
    /// This class helps the representation of a hierarchical grid in isnet.webgrid.
    /// </summary>
    public class CMElementCollectionUI : CollectionBase, IHierarchicalList, IObjectRelations
    {
        #region Public methods

        public CMElementCollectionUI(IList<Element> _elements)
        {
            setMaskElements(_elements);
        }

        public CMElementCollectionUI()
        {
        }

        public void Add(CMElementUI __elementMask)
        {
            __elementMask.Owner = this;
            int i = 0;
            foreach (CMElementUI masked in List)
            {
                if (__elementMask.Position <= masked.Position)
                    break;
                i++;
            }
            List.Insert(i, __elementMask);
        }


        public void AddAndRename(CMElementUI __elementMask)
        {
            //and the element and then change the name, because maybe it's copy of the element

            __elementMask.ElementName = setNewName(__elementMask.ElementName);
            Add(__elementMask);
        }

        private string setNewName(string __baseName)
        {
            int idNextName = 0;
            foreach (CMElementUI el in List)
            {
                if (el.ElementName.StartsWith(__baseName))
                {
                    if (el.ElementName.Length > __baseName.Length + 1)
                    {
                        String nextStr = el.ElementName.Substring(__baseName.Length + 1);
                        Int32 iParamenter;
                        bool bSuccess = Int32.TryParse(nextStr, NumberStyles.Integer, null, out iParamenter);
                        if (bSuccess)
                            idNextName++;
                    }
                }
            }
            return __baseName + "_" + (idNextName + 1);
        }

        public bool Remove(int index)
        {
            // Check to see if there is a customer at the supplied index.
            if (index > Count - 1 || index < 0)
            {
                return false;
            }
            else
            {
                List.RemoveAt(index);
                return true;
            }
        }

        public void Remove(CMElementUI cust)
        {
            List.Remove(cust);
        }

        public CMElementUI Item(int Index)
        {
            if (Index >= List.Count)
                throw new Exception("Out of bound.");
            return (CMElementUI) List[Index];
        }

        public CMElementUI FindByID(int __ElementId)
        {
            foreach (CMElementUI c in InnerList)
            {
                if (c.ElementID == __ElementId)
                    return c;
            }
            return null;
        }

        public CMElementUI FindByName(String __ElementName)
        {
            foreach (CMElementUI c in InnerList)
            {
                if (c.ElementName == __ElementName)
                    return c;
            }
            return null;
        }

        public bool existById(int __ElementId)
        {
            foreach (CMElementUI c in InnerList)
            {
                if (c.ElementID == __ElementId)
                    return true;
            }
            return false;
        }

        public bool existByName(String __ElementName)
        {
            foreach (CMElementUI c in InnerList)
            {
                if (c.ElementName == __ElementName)
                    return true;
            }
            return false;
        }

        public bool existByNameExludeId(String __ElementName, int __ElementId)
        {
            foreach (CMElementUI c in InnerList)
            {
                if (c.ElementName == __ElementName && c.ElementID != __ElementId)
                    return true;
            }
            return false;
        }

        public void setMaskElements(IList<Element> __list)
        {
            foreach (Element el in __list)
            {
                Add(new CMElementUI(el));
            }
        }

        public void ReorderPositions()
        {
            int truePos = 0;
            foreach (CMElementUI el in List)
            {
                if (el.Position != truePos)
                    el.Position = truePos;
                truePos++;
            }
        }

        #endregion

        #region IHierarchicalList Members

        public Type ItemType
        {
            get { return typeof (CMElementUI); }
        }

        #endregion

        #region IObjectRelations Members

        public ArrayList Relations
        {
            get
            {
                CMObjectRelationsUI relations = new CMObjectRelationsUI();
                return relations.Relations;
            }
        }

        #endregion

        #region Test Methods

        public static CMElementCollectionUI getElementCollection()
        {
            CMElementCollectionUI customers =
                new CMElementCollectionUI(SessionObjects.getTestObject.TestCasesStruct.Elements);
            return customers;
        }

        #endregion
    }
}