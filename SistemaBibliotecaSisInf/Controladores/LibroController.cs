using SistemaBibliotecaSisInf.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBibliotecaSisInf.Controladores
{
    internal class LibroController
    {
        bibliotecabdEntitiesSis _db = new bibliotecabdEntitiesSis();
        public List<Libro> listar()
        {
            return _db.Libro.ToList();
        }

        public List<Libro> buscar(string param)
        {
            if (param.Trim().Equals(String.Empty))
                return listar();
            else
            {
                return _db.Libro.Where(
                    q => q.Codigo.Contains(param) || q.Titulo.Contains(param) || q.Autor.Contains(param)
                ).ToList();
            }
        }

        public bool insertar(Libro libro)
        {
            libro.Estado = "Libre";
            _db.Libro.Add(libro);
            return _db.SaveChanges() > 0;
        }

        public bool modificar(Libro libro)
        {
            _db.Libro.Attach(libro);
            _db.Entry(libro).State = System.Data.EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        public bool eliminar(int libroId)
        {
            Libro libro = _db.Libro.Find(libroId);
            _db.Libro.Remove(libro);
            return _db.SaveChanges() > 0;
        }
        
        public List<Libro> buscarLibroEstudiante(string par) 
        {
            par = par.ToLower().Trim(); //eliminar espacios
            return _db.Libro.Where(q => 
                q.Titulo.ToLower().Contains(par) || 
                q.Codigo.ToLower().Contains(par) ||
                q.Autor.ToLower().Contains(par)
            ).ToList();
        }
    }
}
