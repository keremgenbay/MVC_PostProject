using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MetaBLL
    {
        MetaDAO metadao=new MetaDAO();
        public bool AddMeta(MetaDTO model)
        {
            Meta meta=new Meta();
            meta.Name = model.Name;
            meta.MetaContent = model.MetaContent;
            meta.AddDate=DateTime.Now;
            meta.LastUpdateDate = DateTime.Now;
            meta.LastUpdateUserID=UserStatic.UserID;
            int metaID = metadao.AddMeta(meta);
            LogDAO.AddLog(General.ProcessType.MetaAdd,General.TableName.Meta,metaID);
            return true;
        }
    }
}
