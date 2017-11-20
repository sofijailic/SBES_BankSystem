﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            //ovde ucitati informacije o korisnicima i racunima

            //BankDB.BazaKorisnika.Add("admin", new User("admin","admin","admin","0000",20000));
            ucitajKorisnike(BankDB.BazaKorisnika);
            ucitajRacune(BankDB.BazaRacuna);

            BankServer server = new BankServer();
            server.Start();

            Console.ReadKey();
        }

        private static void ucitajKorisnike(Dictionary<string, User> recnikKorisnika)
        {
            try
            {
                string putanja = Environment.CurrentDirectory + "\\korisnici.xml";

                List<User> listaKorisnika = new List<User>();
                XmlSerializer xs = new XmlSerializer(typeof(List<User>));
                StreamReader sr = new StreamReader(putanja);
                listaKorisnika = (List<User>)xs.Deserialize(sr);
                sr.Close();
                foreach (User u in listaKorisnika)
                {
                    recnikKorisnika.Add(u.Username, u);
                }
            }
            catch
            {

            }

        }

        private static void ucitajRacune(Dictionary<string, Racun> recnikRacuna)
        {
            try
            {
                string putanja = Environment.CurrentDirectory + "\\racuni.xml";

                List<Racun> listaRacuna = new List<Racun>();
                XmlSerializer xs = new XmlSerializer(typeof(List<Racun>));
                StreamReader sr = new StreamReader(putanja);
                listaRacuna = (List<Racun>)xs.Deserialize(sr);
                sr.Close();
                foreach (Racun r in listaRacuna)
                {
                    recnikRacuna.Add(r.Username, r);
                }

            }
            catch
            {

            }

        }

    }
}
