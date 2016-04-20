using System.Web.Mvc;
using Modelo;
using Controle;
using GrupoRAI.Models;

namespace GrupoRAI.Controllers
{
    public class AccountController : Controller
    {
        private ModeloEntity db = new ModeloEntity();
        public AccountController()
        {
        }
        
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            Session.Clear();
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login log)
        {
            if (!ModelState.IsValid) return View("Login");
            Pessoas logado = new LoginControle().EfetuarLogin(log.Usuario, Utils.GetHashSenha(log.Senha));

            if (logado != null)
            {
                Session["Logado"] = logado;
                return Redirect("~/Home/Index");
            }

            return View("Login");
        }
                
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //Salvar novo usuário
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar([Bind(Include = "Email,Nome,Login,Senha,Nivel")]Pessoas p)
        {
            if (ModelState.IsValid)
            {
                p.Senha = Utils.GetHashSenha(p.Senha);
                bool salvou = new LoginControle().NovoUsuario(p);

                if(salvou)
                    return Redirect("Login");
                else
                    return View(p);
            }

            // Se algo der errado
            return View(p);
        }

        //
        // GET: /Account/LogOff
        [HttpGet]
        public ActionResult Sair()
        {
            Session.Clear();
            return Redirect("Login");
        }
    }
}