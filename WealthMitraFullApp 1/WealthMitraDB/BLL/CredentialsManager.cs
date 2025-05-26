using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class CredentialsManager
    {
        public static CredentialsManager self=null;
        private CredentialsManager(){
            self=this;
        }
        public static CredentialsManager GetManager(){
            CredentialsManager themanager;
            if(self == null){
                themanager = new CredentialsManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }
        public List<Credential> GetAll(){
            return CredentialDAL.GetAll();
        }
        public List<Object> GetCredential(int id)
        {
            return CredentialDAL.GetCredential(id);
        }

        public int ResetPassword(ChangePassword obj)
        {
            return CredentialDAL.ChangePassword(obj);
        }
    }
}