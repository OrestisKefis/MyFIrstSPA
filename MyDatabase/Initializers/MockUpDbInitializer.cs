using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities;
using System.Data.Entity.Migrations;

namespace MyDatabase.Initializers
{
    public class MockUpDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            #region Seeding JediKnights
            ForceUser f1 = new ForceUser("Obi-Wan", "Kenobi", "Lightsaber offence-defence", "https://sm.ign.com/ign_gr/news/o/obi-wan-ke/obi-wan-kenobi-will-premiere-with-two-episodes-on-one-day_ah6m.jpg", 13000, "Light", "Jedi Knight", true, "A legendary Jedi Master, Obi-Wan Kenobi was a noble man and gifted in the ways of the Force. He trained Anakin Skywalker, served as a general in the Republic Army during the Clone Wars, and guided Luke Skywalker as a mentor.");
            ForceUser f2 = new ForceUser("Minch", "Yoda", "Light side Mastery", "https://i.pinimg.com/originals/0d/9e/6b/0d9e6b830642bb88c37f2decc146bbaf.jpg", 17000, "Light", "Jedi Grand Master", true, "Minch Yoda, known by most as simply just Yoda, was a legendary Groglyn male who was regarded as one of the most renowned and powerful Jedi Masters in the history of the Jedi.");
            ForceUser f3 = new ForceUser("Anakin", "Skywalker", "Flight Mastery", "https://i.pinimg.com/750x/5a/a2/e7/5aa2e72d8a316235e1d1b53e829847c4.jpg", 30000, "Light", "Padawan", false, "Anakin Skywalker was a Human male born on the Outer Rim world of Tatooine. He later served the Galactic Republic as a Jedi Knight, and later the Galactic Empire as the Sith Lord Darth Vader. Skywalker was believed to be the one known as 'The Chosen One' of Jedi prophecy, destined to bring balance to the Force.");
            ForceUser f4 = new ForceUser("Darth", "Vader", "Dark side Mastery", "https://img.europapress.es/fotoweb/fotonoticia_20220604132648_1200.jpg", 30000, "Dark", "Supreme Commander", true, "Once a heroic Jedi Knight, Darth Vader was seduced by the dark side of the Force, became a Sith Lord, and led the Empire’s eradication of the Jedi Order. He remained in service of the Emperor -- the evil Darth Sidious -- for decades, enforcing his Master’s will and seeking to crush the fledgling Rebel Alliance. But there was still good in him…");
            ForceUser f5 = new ForceUser("Sheev", "Palpatine", "Lightsaber offence-defence", "https://pbs.twimg.com/media/EyiBBjoXMAU1gEj.jpg", 20000, "Dark", "Sith Emperor", false, "The dark side of the Force is a pathway to many abilities some consider to be unnatural, and Sheev Palpatine is the most infamous follower of its doctrines. Scheming, powerful, and evil to the core, Darth Sidious restored the Sith and destroyed the Jedi Order. Living a double life, he was also Palpatine, a Naboo Senator and phantom menace. He manipulated the political system of the Galactic Republic until he was named Supreme Chancellor -- and eventually Emperor – and ruled the galaxy through fear and tyranny. The galaxy rejoiced when he died at the Battle of Endor, but Sidious had cheated death and patiently plotted a return to power.");
            ForceUser f6 = new ForceUser("Luke", "Skaywalker", "Lightsaber offence-defence", "https://static.tvtropes.org/pmwiki/pub/images/luke_the_hero_small.png", 23000, "Light", "Jedi Knight", false, "Luke Skywalker was a Tatooine farmboy who rose from humble beginnings to become one of the greatest Jedi the galaxy has ever known. Along with his friends Princess Leia and Han Solo, Luke battled the evil Empire, discovered the truth of his parentage, and ended the tyranny of the Sith.");


            context.ForceUsers.AddOrUpdate(x => x.FirstName, f1,f2,f3,f4,f5,f6);
            context.SaveChanges();
            #endregion
            base.Seed(context);
        }
    }
}
