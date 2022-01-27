using System;

namespace QLgs.EdoCta.API.Model
{
    public class EstadoCta
    {
        public int Id { get; set; }

        public string CodFrac { get; set; }
        public string Exp { get; set; }
        public string NomFrac { get; set; }
        public string Mza { get; set; }
        public string Lote { get; set; }
        public string CodCli { get; set; }
        public string FormCont { get; set; }
        public string SttExp { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal Men { get; set; }
        public decimal SaldoFin { get; set; }
        public decimal SaldoRem { get; set; }
        public int MensRem { get; set; }
        public DateTime FechaCorte { get; set; }
        public string CtaDep { get; set; }
        public string RefBco { get; set; }
        public DateTime FechaUltPag { get; set; }
        public decimal ImpUltPag { get; set; }
        public string MovUltPag { get; set; } // Se actualiza para quitar el Folio
        public string EdoCtaDt { get; set; }
        public string EdoCtaR { get; set; }
        public string AvisoExp { get; set; }
        public string SigMen { get; set; }
        public DateTime FechaVen { get; set; }
        public decimal SdoSigMen { get; set; }
        public decimal OtrosAdeudos { get; set; }
        public string Secuencia { get; set; }
        public string CodCtaDepPL { get; set; }
        public string Email { get; set; }
        //Adicionales para el Web
        public string Folio { get; set; }        
        public string Moneda { get; set; }
        public decimal TotalAPagar { get; set; }
        public decimal SoloVencido { get; set; }
        public decimal Mensualidades { get; set; }
        public decimal GastoCobranza { get; set; }
        public decimal TotalMoratorios { get; set; }
        public string FormaDePago { get; set; }


    }
}