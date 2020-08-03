using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travelProject.Models;

using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;


namespace travelProject.Controllers
{
    public class AccountController : Controller
    {
        travelEntities dataBase = new travelEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult signUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signUp(tbl_user signUpValue, HttpPostedFileBase picture)
        {
            //C:\Users\amina\Documents\Visual Studio 2015\Projects\adminPanel\adminPanel\img\user-img\
            // img folder
            string pic = Path.Combine(Server.MapPath("~/images/user-img/"), Path.GetFileName(picture.FileName));
            picture.SaveAs(pic);
            //img to db
            signUpValue.pic = picture.FileName;

            dataBase.tbl_user.Add(signUpValue);
            dataBase.SaveChanges();
            ModelState.Clear();
            return View();
        }

        public ActionResult forgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult forgotPassword(tbl_user forgotPasswordValue)
        {
            
                String password;
                //source = 192.168.20.162\SQLEXPRESS; initial catalog = Payroll_4; user id = sa; password = sa123;
                String mycon = "data source = DESKTOP-RSGMUMQ; Initial Catalog=adminPanel; Integrated Security=True";
                String myquery = "Select * from user_table where Name='" + forgotPasswordValue.name + "' and Email='" + forgotPasswordValue.email + "'";
                SqlConnection con = new SqlConnection(mycon);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myquery;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Label3.Text = "Data Found";

                    password = ds.Tables[0].Rows[0]["password"].ToString();
                    sendpassword(password, forgotPasswordValue.email);
                    ViewBag.message = "Your Password Has Been Sent to Registered Email Address. Check Your Mail Inbox";

                }
                else
                {
                    ViewBag.message = "Your Username is Not Valid or Email Not Registered";

                }
                con.Close();
            

            return View();
        }

        private void sendpassword(string password, string email)
        {
            throw new NotImplementedException();
        }

        private void sendpassword(String password, String email, String name)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("robinjone12@gmail.com", "kandyman86");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Forgot Password ( AdminPanel )";
            msg.Body = "Dear " + name + ", Your Password is  " + password + "\n\n\nThanks & Regards\n AdminPanel";
            msg.To.Add(email);
            string fromaddress = "AdminPanel <robinjone12@gmail.com>";
            msg.From = new MailAddress(fromaddress);
            try
            {
                smtp.Send(msg);

            }
            catch
            {
                throw;
            }

        }
        public ActionResult resetPassword()
        {
            return View();
        }
    }
}