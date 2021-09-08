using Moq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UserManagement.Core.Http;
using UserManagement.Data.Services;
using Xunit;

namespace UserManagement.Tests.Data
{
    public class ViaCepServiceTest
    {
        [Fact]
        public async Task GetCep()
        {
            var message = new HttpResponseMessage();
            message.StatusCode = System.Net.HttpStatusCode.OK;
            message.Content = new StringContent(@"{'cep':'01001-000','logradouro':'Praça da Sé','complemento':'lado ímpar','bairro':'Sé','localidade':'São Paulo','uf':'SP','ibge':'3550308','gia':'1004','ddd':'11','siafi':'7107'}");
            message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");
            Mock<IHttpHandler> client = new Mock<IHttpHandler>();

            client.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(message);

            ViaCepService service = new ViaCepService(client.Object);
            var response = await service.Get("01001-000");
            Assert.Equal("São Paulo", response.Localidade);
            Assert.Equal("SP", response.Uf);
        }

        [Fact(DisplayName = "Throws an NullReferenceException on get Cep")]
        public async Task ErrorOnGetCep()
        {
            Mock<IHttpHandler> client = new Mock<IHttpHandler>();
            client.Setup(x => x.GetAsync(It.IsAny<string>())).Returns<HttpResponseMessage>(null);

            ViaCepService service = new ViaCepService(client.Object);
            await Assert.ThrowsAsync<NullReferenceException>(() => service.Get("01001-000"));
        }
    }
}
