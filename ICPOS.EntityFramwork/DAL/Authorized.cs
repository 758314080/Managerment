﻿/**  版本信息模板在安装目录下，可自行修改。
* Authorized.cs
*
* 功 能： N/A
* 类 名： Authorized
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018/7/24 15:38:16   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using ICPOS.Common;

namespace ICPOS.EntityFramwork.DAL
{
	/// <summary>
	/// 数据访问类:Authorized
	/// </summary>
	public partial class Authorized
	{
		public Authorized()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Authorized_ID", "Authorized"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Authorized_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Authorized");
			strSql.Append(" where Authorized_ID=@Authorized_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Authorized_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Authorized_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ICPOS.EntityFramwork.Model.Authorized model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Authorized(");
			strSql.Append("Role_ID,Module_ID,Crud_Operation)");
			strSql.Append(" values (");
			strSql.Append("@Role_ID,@Module_ID,@Crud_Operation)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Int,4),
					new SqlParameter("@Module_ID", SqlDbType.Int,4),
					new SqlParameter("@Crud_Operation", SqlDbType.Int,4)};
			parameters[0].Value = model.Role_ID;
			parameters[1].Value = model.Module_ID;
			parameters[2].Value = model.Crud_Operation;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ICPOS.EntityFramwork.Model.Authorized model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Authorized set ");
			strSql.Append("Role_ID=@Role_ID,");
			strSql.Append("Module_ID=@Module_ID,");
			strSql.Append("Crud_Operation=@Crud_Operation");
			strSql.Append(" where Authorized_ID=@Authorized_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Role_ID", SqlDbType.Int,4),
					new SqlParameter("@Module_ID", SqlDbType.Int,4),
					new SqlParameter("@Crud_Operation", SqlDbType.Int,4),
					new SqlParameter("@Authorized_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Role_ID;
			parameters[1].Value = model.Module_ID;
			parameters[2].Value = model.Crud_Operation;
			parameters[3].Value = model.Authorized_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Authorized_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Authorized ");
			strSql.Append(" where Authorized_ID=@Authorized_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Authorized_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Authorized_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Authorized_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Authorized ");
			strSql.Append(" where Authorized_ID in ("+Authorized_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ICPOS.EntityFramwork.Model.Authorized GetModel(int Authorized_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Authorized_ID,Role_ID,Module_ID,Crud_Operation from Authorized ");
			strSql.Append(" where Authorized_ID=@Authorized_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Authorized_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = Authorized_ID;

			ICPOS.EntityFramwork.Model.Authorized model=new ICPOS.EntityFramwork.Model.Authorized();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ICPOS.EntityFramwork.Model.Authorized DataRowToModel(DataRow row)
		{
			ICPOS.EntityFramwork.Model.Authorized model=new ICPOS.EntityFramwork.Model.Authorized();
			if (row != null)
			{
				if(row["Authorized_ID"]!=null && row["Authorized_ID"].ToString()!="")
				{
					model.Authorized_ID=int.Parse(row["Authorized_ID"].ToString());
				}
				if(row["Role_ID"]!=null && row["Role_ID"].ToString()!="")
				{
					model.Role_ID=int.Parse(row["Role_ID"].ToString());
				}
				if(row["Module_ID"]!=null && row["Module_ID"].ToString()!="")
				{
					model.Module_ID=(row["Module_ID"].ToString());
				}
				if(row["Crud_Operation"]!=null && row["Crud_Operation"].ToString()!="")
				{
					model.Crud_Operation=int.Parse(row["Crud_Operation"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Authorized_ID,Role_ID,Module_ID,Crud_Operation ");
			strSql.Append(" FROM Authorized ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Authorized_ID,Role_ID,Module_ID,Crud_Operation ");
			strSql.Append(" FROM Authorized ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Authorized ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Authorized_ID desc");
			}
			strSql.Append(")AS Row, T.*  from Authorized T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Authorized";
			parameters[1].Value = "Authorized_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

