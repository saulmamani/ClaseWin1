using SistemaBibliotecaSisInf.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaBibliotecaSisInf.Controladores
{
    internal class EstudianteController
    {
        bibliotecabdEntitiesSis _db = new bibliotecabdEntitiesSis();
        public List<Estudiante> listar()
        {
            return _db.Estudiante.ToList();
        }

        public List<Estudiante> buscar(string param)
        {
            if (param.Trim().Equals(String.Empty))
                return listar();
            else
            {
                return _db.Estudiante.Where(
                    q => q.Nombre.ToUpper().Contains(param.ToUpper())
                ).ToList();
            }
        }

        public bool insertar(Estudiante estudiante)
        {
            _db.Estudiante.Add(estudiante);
            return _db.SaveChanges() > 0;
        }

        public bool modificar(Estudiante estudiante)
        {
            _db.Estudiante.Attach(estudiante);
            _db.Entry(estudiante).State = System.Data.EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        public bool eliminar(int estudianteId)
        {
            Estudiante estudiante = _db.Estudiante.Find(estudianteId);
            _db.Estudiante.Remove(estudiante);
            return _db.SaveChanges() > 0;
        }
    }
}
