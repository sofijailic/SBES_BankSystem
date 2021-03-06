﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    [ServiceContract]
    public interface IOperatorConnection
    {

        /// <summary>
        /// Primanje podataka od banke, tj kada se novac uploaduje na racun, banka javlja operatoru da poveca
        /// </summary>
        [OperationContract]
        bool UpdateStatus(string korisnikKojiJeUplatio, string operaterKomeJeUplaceno, string suma);

        /// <summary>
        /// Metoda koju banka poziva kako bi javila odgovarajucem operateru da je neki klijent otvorio racun na tom operateru
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        //[OperationContract]
        //bool NotifyRacunAdded(Racun r);


        ///// <summary>
        ///// Metoda koju banka poziva kako bi javila odgovarajucem operateru da je obrisan odredjeni racun
        ///// </summary>
        ///// <param name="r"></param>
        ///// <returns></returns>
        //[OperationContract]
        //bool NotifyRacunDeleted(Racun r);

        ///// <summary>
        ///// Metoda koju banka poziva kako bi javila odgovarajucem operateru da je izmenjen odredjeni racun
        ///// </summary>
        ///// <param name="r"></param>
        ///// <returns></returns>
        //[OperationContract]
        //bool NotifyRacunChanged(Racun r);

        [OperationContract]
        bool AddRacun(Racun r);

    }
}
