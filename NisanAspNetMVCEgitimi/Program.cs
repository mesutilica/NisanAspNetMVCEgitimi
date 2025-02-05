using Microsoft.EntityFrameworkCore;
using NisanAspNetMVCEgitimi.Models;

namespace NisanAspNetMVCEgitimi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(); // Mvc deki Controller ve Viewlar�n �al��mas� i�in gerekli ayar

            builder.Services.AddDbContext<UyeContext>(); // Projede entity framework kullanabilmek i�in gereki ayar
            // builder.Services.AddDbContext<UyeContext>(option => option.UseInMemoryDatabase("UyeDb")); // Projede ger�ek veritaban� yerine cihaz belle�inde �al��an sanal db kullanmam�z� sa�lar.

            var app = builder.Build(); // Yukardaki ayarlarla bir uygulama �rne�i olu�tur

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) // Uygulama �al��ma ortam� IsDevelopment(Geli�tirme ortam�) de�ilse
            {
                app.UseExceptionHandler("/Home/Error"); // Olu�an hatalar� yakala ve uygulamay� /Home/Error adresine y�nlendir. (Home:Controller, Error:Action)
            }
            app.UseStaticFiles(); // Uygulamada statik dosyalar�, yani css, js, resim dosyalar�n� vb �al��t�rmay� destekle

            app.UseRouting(); // Uygulamada routing yap�s�n� kullanarak controller ve action e�le�melerini destekle

            app.UseAuthorization(); // Uygulamada yetkilendirmeyi aktif et

            app.MapControllerRoute( // Uygulamada varsay�lan Route yap�land�rmas�n� aktif et
                name: "default", // ad� default olsun
                pattern: "{controller=Home}/{action=Index}/{id?}"); // Uygulamaya controller ve action belirtilmeden gelinirse varsay�lan olarak Home controller daki Index isimli action � �al��t�r. Burada id? parametresi ? ile parametrik olarak ifade edilmi�tir. Yani gelmeyedebilir.

            app.Run(); // Uygulamay� yukardaki t�m ayarlar� kullanarak �al��t�r.
        }
    }
}
