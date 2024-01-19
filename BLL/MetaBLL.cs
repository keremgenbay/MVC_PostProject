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

        public List<MetaDTO> GetMetaData()
        {
            List<MetaDTO> dtolist= new List<MetaDTO>();
            dtolist = metadao.GetMetaData();
            return dtolist;
        }

        public MetaDTO GetMetaWithID(int ID)
        {
            MetaDTO metadto = new MetaDTO();
            metadto = metadao.GetMetaWithID(ID);
            return metadto;
        }

        public bool UpdateMeta(MetaDTO model)
        {
            metadao.UpdateMeta(model);
            LogDAO.AddLog(General.ProcessType.MetaUpdate, General.TableName.Meta, model.MetaID);
            return true;
        }
    }
}
