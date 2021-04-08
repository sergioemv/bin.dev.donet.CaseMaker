using System;
using System.Data;
using CaseMaker.Localization;

namespace bi.maskClasses.states.CMEstatesUIClass
{
    /// <summary>
    /// Autor: portiz
    /// This class returns a dataset with the states that CaseMakerManages.
    /// Some components needs specifically a dataset and not objects.
    /// </summary>
    public class CMStatesUI
    {
        #region Attributes

        private static DataSet _states;

        #endregion

        #region Attributes

        #endregion

        #region Public methods

        public static DataSet getStates()
        {
            if (_states == null)
                fillStatesDataSet();
            return _states;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// This method fills the dataset with CaseMakerStates
        /// </summary>
        private static void fillStatesDataSet()
        {
            _states = new DataSet();

            DataTable tbl = new DataTable("state");
            DataColumn col;

            col = new DataColumn();
            col.AllowDBNull = false;
            col.Caption = "StateId";
            col.ColumnName = "StateId";
            col.DataType = Type.GetType("System.Byte");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.AllowDBNull = false;
            col.Caption = "StateName";
            col.ColumnName = "StateName";
            col.DataType = Type.GetType("System.String");
            tbl.Columns.Add(col);

            col = new DataColumn();
            col.AllowDBNull = false;
            col.Caption = "StateDescription";
            col.ColumnName = "StateDescription";
            col.DataType = Type.GetType("System.String");
            tbl.Columns.Add(col);

            DataRow r;

            r = tbl.NewRow();
            r["StateId"] = 0;
            r["StateName"] = "+";
            r["StateDescription"] = Resources.PresentationLayer_General_Positive;
            tbl.Rows.Add(r);

            r = tbl.NewRow();
            r["StateId"] = 1;
            r["StateName"] = "-";
            r["StateDescription"] = Resources.PresentationLayer_General_Negative;
            tbl.Rows.Add(r);

            r = tbl.NewRow();
            r["StateId"] = 2;
            r["StateName"] = "F";
            r["StateDescription"] = Resources.PresentationLayer_General_Failure;
            tbl.Rows.Add(r);

            r = tbl.NewRow();
            r["StateId"] = 3;
            r["StateName"] = "I";
            r["StateDescription"] = Resources.PresentationLayer_General_Irrelevant;
            tbl.Rows.Add(r);
            
            _states.Tables.Add(tbl);
        }

        #endregion
    }
}