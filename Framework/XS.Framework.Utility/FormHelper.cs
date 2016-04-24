using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XS.Framework.Utility
{
    public class FormHelper
    {
        /// <summary>
        /// 获得选中行的ID号以“,”相分割
        /// </summary>
        /// <returns></returns>
        public static string GetGridViewSelectedRowId(GridView grid, string chkCtrlName)
        {
            var str = new System.Text.StringBuilder();
            foreach (GridViewRow row in grid.Rows)
            {
                Control chk = row.FindControl(chkCtrlName);
                if (chk != null)
                {
                    if (((CheckBox)chk).Checked)
                    {
                        if (str.ToString() != String.Empty)
                            str.Append(",");
                        str.Append(grid.DataKeys[row.RowIndex].Values[0]);
                    }
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// 获得选中行的ID号以“,”相分割
        /// </summary>
        /// <returns></returns>
        public static string GetGridViewSelectedRowId(GridView grid)
        {
            return GetGridViewSelectedRowId(grid, "Id");
        }

        /// <summary>
        /// 获得选中行的ID号以“,”相分割
        /// </summary>
        /// <returns></returns>
        public static string GetRepeaterSelectedRowId(Repeater repeater, string chkCtrlName)
        {
            return GetRepeaterSelectedRowId(repeater, chkCtrlName, "hfGuId");
        }

        /// <summary>
        /// 获得选中行的ID号以“,”相分割
        /// </summary>
        /// <returns></returns>
        public static string GetRepeaterSelectedRowId(Repeater repeater, string chkCtrlName, string findControl)
        {
            var str = new System.Text.StringBuilder();
            foreach (RepeaterItem item in repeater.Items)
            {
                Control chk = item.FindControl(chkCtrlName);
                if (chk != null)
                {
                    if (((CheckBox)chk).Checked)
                    {
                        var hf = item.FindControl(findControl) as HiddenField;
                        if (hf != null)
                        {
                            if (str.ToString() != String.Empty)
                                str.Append(",");
                            str.Append("'" + hf.Value + "'");
                        }
                    }
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// 获得选中行的ID号以“,”相分割
        /// </summary>
        /// <returns></returns>
        public static string GetRepeaterSelectedRowId(Repeater repeater)
        {
            return GetRepeaterSelectedRowId(repeater, "GuId");
        }
    }
}
