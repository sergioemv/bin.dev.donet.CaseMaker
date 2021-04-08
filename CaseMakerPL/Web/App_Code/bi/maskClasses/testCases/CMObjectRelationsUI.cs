using System.Collections;
using bi.maskClasses.testCases.CMElementUIClass;
using bi.maskClasses.testCases.CMEquivalenceClassUIClass;
using ISNet.WebUI.WebGrid;

namespace bi.maskClasses.testCases
{
    /// <summary>
    /// Autor: portiz
    /// Description: This class manages the relationship between elements and equivalence class, for integrating
    /// to de isnet.webgrid
    /// </summary>
    public class CMObjectRelationsUI : IObjectRelations
    {
        #region IObjectRelations Members

        /// <summary>
        /// The interface member required to support Hierarhical Objects Binding.
        /// </summary>
        /// <remarks>
        /// The purpose of this getter property is simply to collect the definition of each relationship between one business entity and the other.
        /// Use the WebGridObjectRelation object to provide the necessary information, such as:
        /// * The ParentCollection Type, such as CustomerCollection
        /// * The ParentMember property, such as CustomerID. In business object, the parent member is a public property having the same name as the property name.
        /// * The ChildCollection property, such as Orders. The child collection is a public property defined in the parent class which is used to get the collection of child objects.
        /// * The ChildCollection Type, such as EquivalenceClassCollection
        /// * The ChildMember property, such as CustomerID. The child member is a public property defined in the child class (which is Order class in this context).
        /// 
        /// All the 5 information above are essential and required in order to establish a relationship between one entity and another, which has following objectives:
        /// * Automatic data binding. That is, all you need to do is providing the Collection as the DataSource. WebGrid will handle the rest.
        /// * All data-aware features are supported. Business objects are essential and should be treated with priority. 
        ///   You will be able to perform all data-aware features automatically, without any additional implementation in your business object.
        ///   The data-aware features are such as sorting, grouping, filtering, editing, unlimited nested hierarchies, etc.
        /// * Consistency with existing feature-sets. That is, you can enable other features without complication and coding the same way as if you're using DataSet.
        /// </remarks>
        public ArrayList Relations
        {
            get
            {
                ArrayList relations = new ArrayList();
                relations.Add(
                    new WebGridObjectRelation(typeof (CMElementCollectionUI), "ElementID", "EquivalentClasses",
                                              typeof (CMEquivalenceClassCollectionUI), "ElementId"));
                return relations;
            }
        }

        #endregion
    }
}