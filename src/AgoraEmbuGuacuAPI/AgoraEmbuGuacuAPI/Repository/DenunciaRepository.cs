﻿using AgoraEmbuGuacuAPI.Context;
using AgoraEmbuGuacuAPI.Entities;
using AgoraEmbuGuacuAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgoraEmbuGuacuAPI.Repository
{
    public class DenunciaRepository : IDenunciaRepository
    {
        private readonly AgoraContext _context;
        private List<Denuncia> denuncias = new List<Denuncia>();

        public DenunciaRepository(AgoraContext context)
        {
            _context = context;
        }

        public IEnumerable<Denuncia> ListarDenuncias()
        {
            return _context.Denuncias
                .Include(d => d.Comentarios) 
                .ToList();
        }



        public void AdicionarDenuncia(Denuncia denuncia)
        {
            _context.Denuncias.Add(denuncia);
            _context.SaveChanges();
        }

        public void AtualizarDenuncia(Denuncia denuncia)
        {
            var existingDenuncia = _context.Denuncias.Find(denuncia.Id);

            if (existingDenuncia != null)
            {
                existingDenuncia.Titulo = denuncia.Titulo;
                existingDenuncia.Descricao = denuncia.Descricao;
                
                _context.SaveChanges(); 
            }
        }

        public void AdicionarComentario(int denunciaId, Comentario comentario)
        {
            var denuncia = _context.Denuncias.Include(d => d.Comentarios).FirstOrDefault(d => d.Id == denunciaId);

            if (denuncia != null)
            {
                if (denuncia.Comentarios == null)
                {
                    denuncia.Comentarios = new List<Comentario>();
                }

                

                denuncia.Comentarios.Add(comentario);

                _context.SaveChanges(); 
            }
        }


        public Denuncia ObterDenunciaPorId(int id)
        {
            return _context.Denuncias
                .Include(d => d.Comentarios) 
                .FirstOrDefault(d => d.Id == id);
        }



        public void ExcluirDenuncia(int id)
        {
            var denuncia = _context.Denuncias.FirstOrDefault(d => d.Id == id);
            if (denuncia != null)
            {
                _context.Denuncias.Remove(denuncia);
                _context.SaveChanges();
            }
        }

    }
}
