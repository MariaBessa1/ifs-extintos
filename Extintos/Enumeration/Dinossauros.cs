using System;
using System.Reflection;

namespace Extintos.Enumeration
{
   
    [AttributeUsage(AttributeTargets.Field)]
    internal class DinossauroInfo : Attribute
    {
        public string Nome { get; }
        public string Cor { get; }
        
        public string Codigo { get; }

        //public int Quantidade { get; set; }

        public DinossauroInfo(string nome, string cor, string codigo)
        
        {   
            Cor = cor;
            Nome = nome;
            Codigo = codigo;

        }
        
    }
    
    public enum Dinossauro
    {
        
        //comentário repetido a seguir usado somente para retirar o aviso automático do rider
        
        [DinossauroInfo("(BR) Braquiossauro", "Roxo", "BR")]
        // ReSharper disable once InconsistentNaming
        BR,
        [DinossauroInfo("(EP) Espinossauro", "Laranja","EP")]
        // ReSharper disable once InconsistentNaming
        EP,
        [DinossauroInfo("(ET) Estegossauro","Azul", "ET")]
        // ReSharper disable once InconsistentNaming
        ET,
        [DinossauroInfo("(PA) Parasaurolófo", "Verde","PA")]
        // ReSharper disable once InconsistentNaming
        PA,
        [DinossauroInfo("(TI) Tiranossauro","Vermelho","TI")]
        // ReSharper disable once InconsistentNaming
        TI,
        [DinossauroInfo("(TR) Tricerátops", "Amarelo","TR")]
        // ReSharper disable once InconsistentNaming
        TR
    }

   
    
    internal static class DinoExtension
    {
        public static DinossauroInfo GetInfo(this Dinossauro dino)
        {
            var field = dino.GetType().GetField(dino.ToString());
            return field?.GetCustomAttribute<DinossauroInfo>();
        }

        public static string PegaNome(this Dinossauro dino)
        {
            return dino.GetInfo()?.Nome ?? dino.ToString();
        }

        public static string PegaCor(this Dinossauro dino)
        {
            return dino.GetInfo()?.Cor;
        }
        
        public static string PegaCodigo(this Dinossauro dino)
        {
            return dino.GetInfo()?.Codigo;
        }
    }
}


    
  