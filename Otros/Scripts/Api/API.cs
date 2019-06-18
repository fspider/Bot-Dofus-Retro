﻿using Bot_Dofus_1._29._1.Otros.Scripts.Manejadores;
using MoonSharp.Interpreter;
using System;

/*
    Este archivo es parte del proyecto BotDofus_1.29.1

    BotDofus_1.29.1 Copyright (C) 2019 Alvaro Prendes — Todos los derechos reservados.
    Creado por Alvaro Prendes
    web: http://www.salesprendes.com
*/

namespace Bot_Dofus_1._29._1.Otros.Scripts.Api
{
    [MoonSharpUserData]
    public class API : IDisposable
    {
        public InventarioApi inventario { get; private set; }
        public PersonajeApi personaje { get; private set; }
        private bool disposed;

        public API(Cuenta cuenta, ManejadorAcciones manejar_acciones)
        {
            inventario = new InventarioApi(cuenta, manejar_acciones);
            personaje = new PersonajeApi(cuenta);
        }

        #region Zona Dispose
        ~API() => Dispose(false);
        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    inventario.Dispose();
                    personaje.Dispose();
                }

                inventario = null;
                personaje = null;
                disposed = true;
            }
        }
        #endregion
    }
}