using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Master_detail.Models;

namespace Master_detail.ModelView
{
    public class EMPMV
    {

        string oradb = "Data Source=dbtest;User ID=psl;Password=psl;";

        public void AddNewDEPT(Dept dept)
        {
            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "insert into dept values(:deptno,:dname,:loc)";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.Add(new OracleParameter("deptno", dept.Deptid));
            cmd.Parameters.Add(new OracleParameter("dname", dept.Dname));
            cmd.Parameters.Add(new OracleParameter("loc", dept.Location));

            cmd.ExecuteNonQuery();
        }

        public void AddNewEmployee(EMP emp)
        {
            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "insert into emp values(:empno,:ename,:job,:mgr,:hiredate,:sal,:comm,:deptno)";
            cmd.Connection = con;
            con.Open();

            cmd.Parameters.Add(new OracleParameter("empno", emp.EMPNO));
            cmd.Parameters.Add(new OracleParameter("ename", emp.ENAME));
            cmd.Parameters.Add(new OracleParameter("job", emp.JOB));
            cmd.Parameters.Add(new OracleParameter("mgr", emp.MGR));
            cmd.Parameters.Add(new OracleParameter("hiredate", emp.HIREDATE));
            cmd.Parameters.Add(new OracleParameter("sal", emp.SAL));
            cmd.Parameters.Add(new OracleParameter("comm", emp.COMM));
            cmd.Parameters.Add(new OracleParameter("deptno", emp.DEPTNO));


            cmd.ExecuteNonQuery();
        }

        public EMP AutoGenerate()
        {
            EMP employee = new EMP();
            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "Select max(nvl(Deptno,0))+10 as Deptid From dept";
            cmd.Connection = con;
            con.Open();


            OracleDataReader reader = cmd.ExecuteReader();

            reader.Read();

            employee.Deptid = Convert.ToInt16(reader["Deptid"]);

            reader.Close();
            return employee;
        }


        public EMP AutoGenerateEMPNO()
        {
            EMP employee = new EMP();
            OracleConnection con = new OracleConnection(oradb);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "Select max(nvl(empno,0))+1 as Empno From emp";
            cmd.Connection = con;
            con.Open();


            OracleDataReader reader = cmd.ExecuteReader();

            reader.Read();

            employee.EMPNO = Convert.ToInt16(reader["Empno"]);

            reader.Close();

            return employee;
        }
    }
}