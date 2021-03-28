using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MovieSystem.SQLCommon
{
    public static class SQLHelper
    {
        // 返回字典集合
        public static Dictionary<string, object> SQLParam(dynamic obj)
        {
            
            PropertyInfo[] InfoArray = obj.GetType().GetProperties();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            List<PropertyInfo> ls = new List<PropertyInfo>();
            foreach (var item in InfoArray)
            {
                if (item.GetValue(obj) != null)
                {
                    ls.Add(item);
                }
            }
            foreach (PropertyInfo item in ls)
            {
                dic.Add(String.Format("@{0}", item.Name), item.GetValue(obj));
            }
            return dic;
        }
        // Update语句
        public static string UpdateSQL(dynamic obj)
        {
            PropertyInfo[] InfoArray = obj.GetType().GetProperties();
            List<PropertyInfo> ls = new List<PropertyInfo>();
            foreach (var item in InfoArray)
            {
                if (item.GetValue(obj) != null)
                {
                    ls.Add(item);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("update ");
            sb.Append(obj.GetType().Name);
            sb.Append(" set ");
            for (int i = 1; i < ls.Count; i++)
            {
                if (ls[i].GetValue(obj) != null)
                {
                    string PropertyName = ls[i].Name;
                    sb.Append(PropertyName);
                    sb.Append("=@");
                    sb.Append(PropertyName);
                    if (i < ls.Count - 1)
                    {
                        sb.Append(" , ");
                    }
                }
            }
            sb.Append(" where ");
            sb.Append(ls[0].Name);
            sb.Append("=@");
            sb.Append(ls[0].Name);
            return sb.ToString();
        }
        // Insert语句
        public static string InsertSQL(dynamic obj)
        {
            PropertyInfo[] InfoArray = obj.GetType().GetProperties();
            List<PropertyInfo> ls = new List<PropertyInfo>();
            foreach (var item in InfoArray)
            {
                if (item.GetValue(obj) != null)
                {
                    ls.Add(item);
                }
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into  ");
            sb.Append(obj.GetType().Name);
            sb.Append(" (");
            for (int i = 0; i < ls.Count; i++)
            {
                string PropertyName = ls[i].Name;
                sb.Append(PropertyName);
                if (i < ls.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append(") values (");
            for (int i = 0; i < ls.Count; i++)
            {

                string PropertyName = ls[i].Name;
                sb.Append("@");
                sb.Append(PropertyName);
                if (i < ls.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append(")");
            return sb.ToString();
        }
        // Select语句
        public static string SelectSQL(dynamic obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from ");
            sb.Append(obj.GetType().Name);
            PropertyInfo[] InfoArray = obj.GetType().GetProperties();
            List<PropertyInfo> ls = new List<PropertyInfo>();
            foreach (var item in InfoArray)
            {
                if (item.GetValue(obj) != null)
                {
                    ls.Add(item);
                }
            }
            if (ls.Count > 0)
            {
                sb.Append(" where ");
                for (int i = 0; i < ls.Count; i++)
                {
                    sb.Append(ls[i].Name);
                    sb.Append("=@");
                    sb.Append(ls[i].Name);
                    if (i < ls.Count - 1)
                    {
                        sb.Append(" and ");
                    }
                }
            }
            return sb.ToString();
        }
        // Count查询
        public static string SelectCountSQL(dynamic obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select Count(*) from ");
            sb.Append(obj.GetType().Name);
            PropertyInfo[] InfoArray = obj.GetType().GetProperties();
            List<PropertyInfo> ls = new List<PropertyInfo>();
            foreach (var item in InfoArray)
            {
                if (item.GetValue(obj) != null)
                {
                    ls.Add(item);
                }
            }
            if (InfoArray.Length > 0)
            {
                sb.Append(" where ");
                for (int i = 0; i < ls.Count; i++)
                {

                    sb.Append(InfoArray[i].Name);
                    sb.Append("=@");
                    sb.Append(InfoArray[i].Name);
                    if (i < InfoArray.Length - 1)
                    {
                        sb.Append(" and ");
                    }
                }
            }
            return sb.ToString();
        }

        // Row_Number单表查询，分页时使用。
        public static string SelectRowNumberSQL(dynamic obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ROW_NUMBER() over(order by Id desc) as num,* from ");
            sb.Append(obj.GetType().Name);
            PropertyInfo[] InfoArray = obj.GetType().GetProperties();
            List<PropertyInfo> ls = new List<PropertyInfo>();
            foreach (var item in InfoArray)
            {
                if (item.GetValue(obj) != null)
                {
                    ls.Add(item);
                }
            }
            if (InfoArray.Length > 0)
            {
                sb.Append(" where ");
                for (int i = 0; i < ls.Count; i++)
                {
                    sb.Append(InfoArray[i].Name);
                    sb.Append("=@");
                    sb.Append(InfoArray[i].Name);
                    if (i < InfoArray.Length - 1)
                    {
                        sb.Append(" and ");
                    }
                }
            }
            return sb.ToString();
        }

        //Delete语句
        public static string DeleteSQL(dynamic obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from  ");
            sb.Append(obj.GetType().Name);
            sb.Append(" where ");
            PropertyInfo[] InfoArray = obj.GetType().GetProperties();
            sb.Append(InfoArray[0].Name);
            sb.Append("=@");
            sb.Append(InfoArray[0].Name);
            return sb.ToString();
        }


    }
}
