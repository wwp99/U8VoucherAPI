using PublicVatti.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace U8VoucherAPI.Models
{
    /// <summary>
    /// 新增供应商
    /// </summary>
    public class VendorService
    {
        public string Add(string corporationid, Vendor ven,out string odd)
        {
            odd = "";
            try
            {
                if (ven == null)
                    return "数据不能为空";
                if (string.IsNullOrEmpty(ven.name))
                    return "供应商名称不能为空";
                if (string.IsNullOrEmpty(ven.abbrname))
                    return "供应商简称不能为空";
                if (string.IsNullOrEmpty(ven.sort_code))
                    return "供应商分类编码不能为空";

                string sql = $" select U8ZT from UFSystem..Company_U8 where CompanyID = {corporationid} ";
                string U8ZT = DB.RunProcScalar(sql);
                if (string.IsNullOrEmpty(U8ZT))
                {
                    return "请输入正确的公司ID";
                }
                else
                {
                    sql = $" select cVCName from {U8ZT}..VendorClass where cVCCode='{ven.sort_code}'  ";
                    if (string.IsNullOrEmpty(DB.RunProcScalar(sql)))
                        return "供应商分类不正确！";

                    sql = $" select cVenCode from {U8ZT}..Vendor where cVenAbbName = '{ven.abbrname}' ";
                    if (!string.IsNullOrEmpty(DB.RunProcScalar(sql)))
                        return "供应商简称已存在！";


                    if (string.IsNullOrEmpty(ven.cVenExch_name))
                    {
                        ven.cVenExch_name = "人民币";
                    }

                    if (string.IsNullOrEmpty(ven.cCreatePerson))
                    {
                        ven.cCreatePerson = "金马同步";
                    }

                    switch (ven.bvencargo)
                    {
                        case 0:
                            ven.bVenCargo = 1;
                            break;
                        case 1:
                            ven.bProxyForeign = 1;
                            break;
                        case 2:
                            ven.bVenService = 1;
                            break;
                        default:
                            break;
                    }

                    //有流水号加一 没有默认00001
                    //sql = $" select MAX(SUBSTRING(cVenCode,3,9)) from Vendor where cVCCode ='{ven.sort_code}' ";
                    //if (!string.IsNullOrEmpty(DB.RunProcScalar(sql)))
                    //{
                    //    int code = int.Parse(DB.RunProcScalar(sql)) + 1;
                    //    if (code < 10000)
                    //    {
                    //        ven.code = ven.sort_code + code.ToString().PadLeft(5, '0');
                    //    }
                    //    else
                    //    {
                    //        ven.code = ven.sort_code + code;
                    //    }
                    //}
                    //else
                    //{
                    //    string code = "00001";
                    //    ven.code = ven.sort_code + code;

                    //}
                    
                    odd = "000997";

                    sql = $" insert into {U8ZT}..Vendor(cVenCode,cVenName,cVenAbbName,bBusinessDate,bLicenceDate,bPassGMP,bProxyDate,bVenAccPeriodMng,bProxyForeign,bVenCargo,bVenOverseas,bVenHomeBranch,iVenGSPType,bVenTax,cCreatePerson,dVenCreateDatetime,dVenDevDate,dModifyDate,cVCCode,cVenExch_name,cVenPhone,cVenMnemCode,cVenAddress,cVenLPerson,cVenBank,cVenAccount,cVenFax,cVenEmail,cVenPerson,cVenHand,iVenTaxRate,cMemo) values('{ven.code}','{ven.name}','{ven.abbrname}',{ven.bBusinessDate},{ven.bLicenceDate},{ven.bPassGMP},{ven.bProxyDate},{ven.bVenAccPeriodMng},{ven.bProxyForeign},{ven.bVenCargo},{ven.bVenOverseas},{ven.bVenHomeBranch},{ven.iVenGSPType},{ven.bVenTax},'{ven.cCreatePerson}',GETDATE(),GETDATE(),GETDATE(),'{ven.sort_code}','{ven.cVenExch_name}','{ven.phone}','{ven.cVenMnemCode}','{ven.address}','{ven.cVenLPerson}','{ven.bank_open}','{ven.bank_acc_number}','{ven.fax}','{ven.email}','{ven.contact}','{ven.mobile}','{ven.iVenTaxRate}','{ven.memo}') ";
                    int count = DB.RunProcNonQuery(sql);
                    return count > 0 ? "" : "插入失败";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}