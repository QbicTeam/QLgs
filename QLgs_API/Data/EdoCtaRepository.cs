using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLgs.EdoCta.API.Helpers.DataBaseAccess;
using QLgs.EdoCta.API.Model;
using QLgs.EdoCta.API.Model.Enums;

namespace QLgs.EdoCta.API.Data
{
    public class EdoCtaRepository: IEdoCtaRepository
    {        

        public EdoCtaRepository() {}

        public Task<bool> ChangePassword(string username, string password, string newPassword)
        {
            throw new System.NotImplementedException();
        }


        public async Task<List<EstadoCta>> GetExpsCliente(string codCli)
        {
            var exps = new List<EstadoCta>();
            EstadoCta exp;            
            var ado = new SQLAccess();
            var idx = 0;
            var parms = ado.IniListParameter();

            parms.Add(ado.GetParameter("CodCli", codCli));
            
            var data = await ado.GetDataReader("GetEdoCtaClienteWeb", parms);

            if (data.HasRows)
            {
                while (data.Read())
                {
                    exp = new EstadoCta();
                    exp.CodCli = data["CodCli"].ToString();
                    exp.CodFrac = data["CodFrac"].ToString();
                    exp.NomFrac = data["NomFrac"].ToString();
                    exp.Exp = data["Exp"].ToString();
                    exp.Mza = data["Mza"].ToString();
                    exp.Lote = data["Lote"].ToString();
                    exp.FormCont = data["FormCont"].ToString();
                    exp.SttExp = data["SttExp"].ToString();
                    exp.TotalPagar = Convert.ToDecimal(data["CodFrac"].ToString());
                    exp.Men = Convert.ToDecimal(data["Men"].ToString());
                    exp.SaldoFin = Convert.ToDecimal(data["SaldoFin"].ToString());
                    exp.SaldoRem = Convert.ToDecimal(data["SaldoRem"].ToString());
                    exp.MensRem = Convert.ToInt32(data["MensRem"]);
                    exp.FechaCorte = Convert.ToDateTime(data["FechaCorte"].ToString());
                    exp.CtaDep = data["CtaDep"].ToString();
                    exp.RefBco = data["RefBco"].ToString();
                    exp.FechaUltPag = Convert.ToDateTime(data["FechaUltPag"].ToString());
                    exp.ImpUltPag = Convert.ToDecimal(data["ImpUltPag"].ToString());
                    exp.MovUltPag = data["MovUltPag"].ToString();
                    exp.EdoCtaDt = data["EdoCtaDt"].ToString();
                    exp.EdoCtaR = data["EdoCtaR"].ToString();
                    exp.AvisoExp = data["AvisosExp"].ToString();
                    exp.SigMen = data["SigMen"].ToString();
                    exp.FechaVen = Convert.ToDateTime(data["FechaVen"].ToString());
                    exp.SdoSigMen = Convert.ToDecimal(data["SdoSigMen"].ToString());
                    exp.OtrosAdeudos = Convert.ToDecimal(data["OtrosAdeudos"].ToString());
                    exp.Secuencia = data["Secuencia"].ToString();
                    exp.CodCtaDepPL = data["CodCtaDepPL"].ToString();
                    exp.Email = data["Email"].ToString();

                    exp.Moneda = data["Moneda"].ToString();
                    
                    var arrPagar = exp.EdoCtaR.Split(',');

                    exp.TotalMoratorios = Convert.ToDecimal(arrPagar[0].Replace("Total Moratorios ", ""));
                    exp.GastoCobranza = Convert.ToDecimal(arrPagar[1].Replace(" Gastos de Cobranza ", "")); ;
                    exp.Mensualidades = Convert.ToDecimal(arrPagar[2].Replace(" Mensualidades ", "")); ;
                    exp.TotalAPagar = exp.Mensualidades + exp.GastoCobranza + exp.TotalMoratorios + exp.OtrosAdeudos;

                    exp.SoloVencido = 0;
                    if (exp.FechaVen <= DateTime.Now)
                        exp.SoloVencido = exp.TotalAPagar;

                    idx = exp.MovUltPag.IndexOf("Folio");
                    exp.Folio = exp.MovUltPag.Substring(idx + 6);
                    exp.MovUltPag = exp.MovUltPag.Substring(0,idx-1);

                    exps.Add(exp);
                }
            }


            return exps;
        }
    }
}