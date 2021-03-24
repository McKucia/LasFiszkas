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
                new Fish() { FishInnerId = 1, SetId = 1, EspContent = "El pan",       PlContent = "Chleb" },
                new Fish() { FishInnerId = 2, SetId = 1, EspContent = "La carne",     PlContent = "Mięso" },
                new Fish() { FishInnerId = 3, SetId = 1, EspContent = "El pollo",     PlContent = "Kurczak" },
                new Fish() { FishInnerId = 4, SetId = 1, EspContent = "La zanahoria",  PlContent = "Marchewka" },
                                                                                      
                new Fish() { FishInnerId = 1, SetId = 2, EspContent = "La bateria",   PlContent = "Perkusja" },
                new Fish() { FishInnerId = 2, SetId = 2, EspContent = "El teclado",   PlContent = "Keyboard" },
                                                                                      
                new Fish() { FishInnerId = 1, SetId = 3, EspContent = "levantarse",   PlContent = "budzić się" },
                new Fish() { FishInnerId = 2, SetId = 3, EspContent = "ducharse",     PlContent = "brać prysznic" },
                new Fish() { FishInnerId = 3, SetId = 3, EspContent = "vestirse",     PlContent = "ubierać się" },
            };

            fishes.ForEach(f => context.Fishes.Add(f));
            context.SaveChanges();

        }
    }
}