using LasFiszkas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LasFiszkas.DAL
{
    public class FishInitializer : DropCreateDatabaseAlways<FishContext>
    {
        protected override void Seed(FishContext context)
        {
            var sets = new List<Set>
            {
                new Set() { Name = "Jedzenie", Description = "To co na stole i w lodówce", IconFilename = "food.png" },
                new Set() { Name = "Instrumenty", Description = "Ba dum tss", IconFilename = "guitar.png" },
                new Set() { Name = "Codzienność", Description = "Czynności codzienne", IconFilename = "everyday.png" }
            };

            sets.ForEach(s => context.Sets.Add(s));
            context.SaveChanges();

            var fishes = new List<Fish>
            {
                new Fish() { SetId = 1, PlContent = "El pan", EspContent = "Chleb" },
                new Fish() { SetId = 1, PlContent = "La carne", EspContent = "Mięso" },
                new Fish() { SetId = 1, PlContent = "El pollo", EspContent = "Kurczak" },
                new Fish() { SetId = 1, PlContent = "La zanahoria", EspContent = "Marchewka" },

                new Fish() { SetId = 2, PlContent = "La bateria", EspContent = "Perkusja" },
                new Fish() { SetId = 2, PlContent = "El teclado", EspContent = "Keyboard" },

                new Fish() { SetId = 3, PlContent = "levantarse", EspContent = "budzić się" },
                new Fish() { SetId = 3, PlContent = "ducharse", EspContent = "brać prysznic" },
                new Fish() { SetId = 3, PlContent = "vestirse", EspContent = "ubierać się" },
            };

            fishes.ForEach(f => context.Fishes.Add(f));
            context.SaveChanges();

        }
    }
}