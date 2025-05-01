# Desenvolvimento-Web-com-.NET-e-Bases-de-Dados-tp1

## Para verificar os exercicios de 8 ate 12 favor entrar no projeto RazorPagesApp

 - Abrir o terminal 
 - cd RazorPagesApp
 - dotnet run

## Para verificar o restante dos exercicios entrar no projeto ConsoleApp
 - Abrir o terminal 
 - cd ConsoleApp1

# Exercicio 1 
#### Codigo:
![img.png](img.png)
#### Resultado:
![img_1.png](img_1.png)

# Exercicio 2
####  Codigo:
![img_4.png](img_4.png)
#### Resultado:
![img_2.png](img_2.png)
![img_3.png](img_3.png)


# Exercicio 3
####  Codigo:
![img_10.png](img_10.png)
![img_11.png](img_11.png)
#### Resultado:
![img_5.png](img_5.png)

# Exercicio 4
####  Codigo:
![img_12.png](img_12.png)
#### Resultado:
![img_7.png](img_7.png)

# Exercicio 5
####  Codigo:
![img_13.png](img_13.png)
#### Resultado:
![img_6.png](img_6.png)

# Exercicio 6
####  Codigo:
![img_14.png](img_14.png)
![img_15.png](img_15.png)
#### Resultado:
![img_8.png](img_8.png)

# Exercicio 7
####  Codigo:
![img_14.png](img_14.png)
![img_16.png](img_16.png)
#### Resultado:
![img_9.png](img_9.png)

# Exercicio 8
####  Codigo:
#### Resultado:

# Exercicio 9
####  1. Qual a função da pasta Pages?
A pasta Pages é onde os arquivos Razor Pages são armazenados. Razor Pages é uma abordagem que permite criar páginas web dinâmicas dentro do ASP.NET Core sem a necessidade de controlar explicitamente a configuração de um controlador MVC. Cada página é representada por um par de arquivos: o arquivo .cshtml, que contém o HTML e o código Razor, e o arquivo .cshtml.cs, que contém a lógica de servidor.
Dentro da pasta Pages, você pode encontrar a página inicial Index.cshtml, mas também pode adicionar outras páginas, como páginas de login, cadastro, e páginas de erro, entre outras.

#### 2. O que faz o arquivo Program.cs?
O arquivo Program.cs é o ponto de entrada da aplicação no ASP.NET Core. Ele contém a configuração inicial e a execução do aplicativo. No arquivo Program.cs, você configura o host da aplicação, que é responsável por iniciar o servidor web e hospedar os arquivos do aplicativo.
No Program.cs, você normalmente verá o seguinte:
Host creation: Criação do host que configura o servidor web.

Startup configuration: Especifica a classe Startup que é responsável por configurar os serviços da aplicação e o pipeline de requisições HTTP.

Web server startup: Chama o método Run(), que inicia o servidor web para servir a aplicação.

Exemplo básico de Program.cs:
```sh
public static IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
webBuilder.UseStartup<Startup>();
});
```

#### 3. Onde são configurados os serviços da aplicação?
Os serviços da aplicação são configurados na classe Startup.cs, mais especificamente no método ConfigureServices. Esse método é chamado durante a inicialização da aplicação e é onde você registra todos os serviços necessários, como:
Serviços de injeção de dependência, como DbContext, Identity, etc.

Configuração de autenticação e autorização.

Adição de middleware, como MVC ou Razor Pages.

Exemplo de configuração de serviço no Startup.cs:
```sh
public void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages(); // Adiciona o serviço de Razor Pages
    // Outras configurações de serviço...
}
```
#### 4.Como é feito o roteamento de URLs?
O roteamento de URLs no ASP.NET Core é configurado principalmente dentro da classe Startup.cs. Através do método Configure, você configura o pipeline de requisições, onde a aplicação define como ela responde a diferentes tipos de URLs.
O roteamento é feito automaticamente quando você adiciona a configuração de Razor Pages usando ``app.UseEndpoints()`` e o ``método MapRazorPages()``:

Exemplo básico de configuração de roteamento:

````sh
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapRazorPages(); // Mapear Razor Pages
    });
}
````
O roteamento do Razor Pages é baseado em uma convenção: o arquivo ``Index.cshtml`` responderá por padrão à URL /, ``About.cshtml`` à URL /About, e assim por diante.

# Exercicio 10
####  Codigo:
![img_18.png](img_18.png)

#### Resultado:
![img_17.png](img_17.png)

# Exercicio 11
####  Codigo:
![img_20.png](img_20.png)
#### Resultado:
![img_19.png](img_19.png)

# Exercicio 12
####  Codigo:
#### Resultado:
