using DemoCRUDnet7.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUDnet7.Services
{
    public class PhotoFakeDb : ICRUDService<Photo>
    {
        private List<Photo> _photos = new List<Photo>
        {
            new Photo(){
                AlbumId = 1,
                Id = 1,
                Title = "accusamus beatae ad facilis cum similique qui sunt",
                Url = "https://via.placeholder.com/600/92c952",
                ThumbnailUrl = "https://via.placeholder.com/150/92c952"
            },
            new Photo(){
                AlbumId = 1,
                Id = 2,
                Title = "reprehenderit est deserunt velit ipsam",
                Url = "https://via.placeholder.com/600/771796",
                ThumbnailUrl = "https://via.placeholder.com/150/771796"
            },
            new Photo(){
                AlbumId = 1,
                Id = 3,
                Title = "officia porro iure quia iusto qui ipsa ut modi",
                Url = "https://via.placeholder.com/600/24f355",
                ThumbnailUrl = "https://via.placeholder.com/150/24f355"
            },
            new Photo(){
                AlbumId = 1,
                Id = 4,
                Title = "culpa odio esse rerum omnis laboriosam voluptate repudiandae",
                Url = "https://via.placeholder.com/600/d32776",
                ThumbnailUrl = "https://via.placeholder.com/150/d32776"
            },
            new Photo(){
                AlbumId = 1,
                Id = 5,
                Title = "natus nisi omnis corporis facere molestiae rerum in",
                Url = "https://via.placeholder.com/600/f66b97",
                ThumbnailUrl = "https://via.placeholder.com/150/f66b97"
            },
        };

        private int _lastId;

        public PhotoFakeDb()
        {
            _lastId = _photos.Count;
        }

        public async Task<bool> Delete(int id)
        {
            var nb = _photos.RemoveAll(p => p.Id == id);
            return nb == 1;
        }

        public async Task<Photo?> Get(int id)
        {
            return _photos.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<Photo>> GetAll()
        {
            return _photos;
        }

        public async Task<bool> Post(Photo photo)
        {
            photo.Id = ++_lastId;
            _photos.Add(photo);
            return true;
        }

        public async Task<bool> Put(Photo photo)
        {
            var pizfromdb = _photos.FirstOrDefault(p => p.Id == photo.Id);
            if (pizfromdb == null) return false;
            pizfromdb = photo;
            return true;
        }
    }
}
