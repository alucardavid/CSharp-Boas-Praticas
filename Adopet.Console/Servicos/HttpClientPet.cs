﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using Adopet.Console.Modelos;

namespace Adopet.Console.Servicos
{
    public class HttpClientPet
    {
        private HttpClient client = new();
        public HttpClientPet(HttpClient client)
        {
            this.client = client;
        }

        public virtual Task CreatePetAsync(Pet pet)
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }

        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}