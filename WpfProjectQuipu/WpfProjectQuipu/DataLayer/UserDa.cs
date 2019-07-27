using WpfProjectQuipu.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjectQuipu.DataLayer.Concrete
{
    class UserDa
    {
        public bool Insert_User(Clients edititems)
        {
            try
            {
                var cmd = Db.CreateCommand();
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                cmd.CommandText = "INSERT INTO dbclients(FirstName, LastName, Phone, Email, Address) VALUES (@firstname, @lastname, @phone, @email, @address);";
                Db.CreateParameterFunc(cmd, "@firstname", edititems.FirstName, SqlDbType.Text);
                Db.CreateParameterFunc(cmd, "@lastname", edititems.LastName, SqlDbType.Text);
                Db.CreateParameterFunc(cmd, "@phone", edititems.Phone, SqlDbType.Text);
                Db.CreateParameterFunc(cmd, "@email", edititems.Email, SqlDbType.Text);
                Db.CreateParameterFunc(cmd, "@address", edititems.Address, SqlDbType.Text);
                var rowsAffected = Db.ExecuteNonQuery(cmd);

                return rowsAffected == 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Update_User(Clients edititems)
        {
            try
            {
                var cmd = Db.CreateCommand();
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                cmd.CommandText = @"UPDATE dbclients 
                SET FirstName =@firstname, LastName =@lastname, Phone =@phone, Email =@email, Address =@address
                             WHERE ID =@clientid; ";
                Db.CreateParameterFunc(cmd, "@clientid", edititems.ClientId, SqlDbType.Int);
                Db.CreateParameterFunc(cmd, "@firstname", edititems.FirstName, SqlDbType.Text);
                Db.CreateParameterFunc(cmd, "@lastname", edititems.LastName, SqlDbType.Text);
                Db.CreateParameterFunc(cmd, "@phone", edititems.Phone, SqlDbType.Text);
                Db.CreateParameterFunc(cmd, "@email", edititems.Email, SqlDbType.Text);
                Db.CreateParameterFunc(cmd, "@address", edititems.Address, SqlDbType.Text);
                var rowsAffected = Db.ExecuteNonQuery(cmd);

                return rowsAffected == 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Delete_User(Clients edititems)
        {
            try
            {
                var cmd = Db.CreateCommand();
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                cmd.CommandText = "DELETE FROM dbclients WHERE Id=@clientid;";
                Db.CreateParameterFunc(cmd, "@clientid", edititems.ClientId, SqlDbType.Int);
                var rowsAffected = Db.ExecuteNonQuery(cmd);

                return rowsAffected == 1;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
