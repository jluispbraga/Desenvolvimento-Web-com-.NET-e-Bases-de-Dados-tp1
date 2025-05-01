using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Models;

public static class EventLogger
{
    public static Action<RazorPagesApp.Models.Event>? OnEventCreated;

    static EventLogger()
    {
        OnEventCreated += (e) =>
        {
            Console.WriteLine($"[LOG] Evento criado: {e.Titulo} em {e.Local} no dia {e.Data:dd/MM/yyyy}");
        };
    }
}


namespace RazorPagesApp.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Event Evento { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            // Disparar delegate
            EventLogger.OnEventCreated?.Invoke(Evento);

            // Redirecionar ou exibir confirmação
            return RedirectToPage("Index");
        }
    }
}