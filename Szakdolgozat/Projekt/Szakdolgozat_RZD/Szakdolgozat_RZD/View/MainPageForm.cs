using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szakdolgozat_RZD
{
    public partial class MainPageForm : Form
    {

        DiplomacyForm df = new DiplomacyForm();
        Model_db M_db = new Model_db();
        M_db_economyf m_db_economyf = new M_db_economyf();
        M_db_mainpagef m_db_mainf = new M_db_mainpagef();
        C_Economy c_e = new C_Economy();

        int count = 0;

        List<string> list_general_informations = new List<string>();
        List<string> list_economy_informations = new List<string>();

        public MainPageForm()
        {
            InitializeComponent();

            
            design(Design.backcolor[0], Design.backcolor[1], Design.backcolor[2], Design.forecolor[0], Design.forecolor[1], Design.forecolor[2]);

            this.Load += (s, e) =>
            {
                if (C_Login.status == "admin")
                {
                    bt_admin.Visible = true;
                    bt_admin.Enabled = true;
                }
            };

            bt_admin.Click += (s, e) => { AdminForm af = new AdminForm(); af.Show(); MainForm fm = new MainForm(); fm.Hide(); };

            //általános országadatok betöltése:
            M_db.list_upload_horizontal(list_general_informations, m_db_mainf.sql_countrys_table, m_db_mainf.list_own_country_sql_query_columns);
            C_MainPageForm aaa = new C_MainPageForm(list_general_informations);

            // gazdasági jellegű országadatok betöltése:
            M_db.list_upload_horizontal(list_economy_informations, m_db_economyf.budget_sql, m_db_economyf.list_budget_sql_query_columns);
            C_Economy ccc = new C_Economy(list_economy_informations);
            C_Economy.available_resources();

            messages();

            economic_exstor_labels();
            economic_available_labels();
            general_inform_labels();
            quote();

        }

        void general_inform_labels()
        {
            c_e.public_services_value_calc();// közszolgáltatás értékek meghatározása számmal -> szükséges az állandóan frissülő populációs adatokhoz is.
            lb_country_name.Text = C_MainPageForm.country_name;
            lb_population_total.Text = string.Format($"{C_MainPageForm.population:N0}");
            lb_born.Text = string.Format($"{c_e.pop_born():N0}");
            lb_mortality.Text = string.Format($"{c_e.mortality():N0}");
            lb_popchange.Text = string.Format($"{C_MainPageForm.population_change:N0}");
            lb_area.Text = string.Format($"{C_MainPageForm.area:N0}");
            lb_tech_age.Text = string.Format($"{C_MainPageForm.tech_age:N0}");
            lb_agro_volumen.Text = string.Format($"{C_MainPageForm.sunshine_hours_class:N0}");
            lb_version.Text = $"{Application.ProductVersion}\nverzió";
        }

        void economic_exstor_labels()
        {
            // kiíratás:
            lb_exstor_money.Text = string.Format($"{C_Economy.expected_money:N0}");
            lb_exstor_food.Text = string.Format($"{C_Economy.expected_food:N0}");
            lb_exstor_building_material.Text = string.Format($"{C_Economy.expected_building_material:N0}");
            lb_exstor_textile.Text = string.Format($"{C_Economy.expected_textile:N0}");
            lb_exstor_weapon.Text = string.Format($"{C_Economy.expected_weapon:N0}");
        }

        void economic_available_labels()
        {
            c_e.sum_cost_money_calc();
            lb_available_money.Text = string.Format($"{C_Economy.storage_money - C_Economy.sum_cost_money + C_Economy.market_money:N0}");
            lb_available_food.Text = string.Format($"{C_Economy.storage_food - C_Economy.cost_food + C_Economy.market_food:N0}");
            lb_available_building_material.Text = string.Format($"{C_Economy.storage_building_material - C_Economy.cost_building_material + C_Economy.market_building_material:N0}");
            lb_available_textile.Text = string.Format($"{C_Economy.storage_textile - C_Economy.cost_textile + C_Economy.market_textile:N0}");
            lb_available_weapon.Text = string.Format($"{C_Economy.storage_weapon - C_Economy.cost_weapon + C_Economy.market_weapon:N0}");
        }

        void messages()
        {
            // új üzenetek számának megjelenítése:
            df.incoming_messages_load();
            for (int i = 0; i < DiplomacyForm.list_incoming.Count / 7; i++)
            {
                if (DiplomacyForm.list_incoming[6 + (i * 7)] == "0")
                {
                    count++;
                }
            }
            if (count > 0)
            {
                lb_messages.Text = $"{count} új üzenet érkezett!";
            }
            else
            {
                lb_messages.Text = $"Nincsen új üzenet";
            }
        }

        void quote()
        {
            #region quote - idézetek
            List<string> quote = new List<string>()
            {
                "Egy elhatározásnak sem lehet nagyobb esélye a sikerre, mint annak amelyiket a végrehajtásig teljes titokban tartunk az ellenségünk előtt. - Niccoló Machiavelli", // 1.
                "Soha semmi jó nem születik az erőszakból. - Luther Márton",
                "Egy hercegnek ezért nem lehet más célja és szándéka…. mint a háború és annak megszervezése, tanulmányozása. - Niccoló Machiavelli",
                "Mindkét oldalt királyi hercegek vezették, és könyörtelenül mészárolták egymást. - Edesszai Máté",
                "Ne okozz kárt az ellenségednek, meglehet, később a barátoddá lesz. - Moslih Eddin Szádi", // 5.
                "A háború a legnagyobb pestis, mert érintheti az embereket, elpusztíthatja a vallást, elpusztíthatja az államokat és elpusztíthatja a családokat. Bármely más csapás kívánatosabb. - Luther Márton",
                "Erős várunk nekünk az Isten. Egy biztos pajzs és fegyver. - Luther Márton",
                "Néhány vereség dicsőségesebb a győzelemnél. - Michel Eyquem de Montaigne",
                "Vállaljátok ezt az utazást, hogy enyhítsétek a bűneiteket a mennyei királyság múlhatatlan dicsőségének ígéretével. - II. Orbán Pápa",
                "S, mert a fejedelemnek jól kell használni állati természetét, a rókát és az oroszlánt kell követnie; az oroszlán tehetetlen a hurokkal szemben, a róka a farkasok elől nem tud menekülni. - Niccoló Machiavelli", // 10.
                "Senki sem kockáztatja a szerencséjét, míg a teljes serege támogatja. - Niccoló Machiavelli",
                "Szereld fel a zarándokokat és arass dicsőséges diadalt keleten és a hitetlenek fölött. - Orderic Vitalis",
                "Le fognak nézni azért, ha valamely gonoszság fegyvertelenül is rávisz valamire. - Niccoló Machiavelli",
                "Ami nem pusztít el, attól erősebb leszek. - John Milton",
                "A háborúk akkor kezdődnek, amikor akarod, de nem akkor érnek véget, amikor szeretnéd. - Niccoló Machiavelli", // 15.
                "Ezért szükséges, hogy a fejedelem hatalmának megóvása érdekében megtanuljon rossznak lenni, és ezt a szükségnek megfelelően gyakorolja. - Niccoló Machiavelli",
                "Nem a név teszi megbecsülté az embert, hanem az ember teszi megbecsülté a nevet. - Niccoló Machiavelli",
                "Bátraké a szerencse. - Erasmus",
                "Az egyedüli dolog, amitől félnünk kell, a félelem maga. - Francis Bacon",
                "Még egy kis fejszével is le lehet dönteni a legkeményebb tölgyet, ha elég sokszor odacsapunk. - Shakespeare, VI. Henrik, III. rész, II. 1", // 20.
                "Jobb egy napot élni oroszlánként, mint száz évet birkaként. - Itáliai közmondás",
                "Mikor vitázni látod ellenségeid, akkor menj és üldögélj nyugodtan a barátaiddal; de ha egyetértést látsz rajtuk, akkor feszítsd ki az íjadat, és rakj ki kövekből védelmet. - Moslih Eddin Szádi",
                "Az igazság hasznavehetetlen fikció csupán. - Friedrich Nietzsche",
                "Ha résztvevői vagyunk, tragédia, ha csak nézői, komédia. - Aldous Huxley",
                "Szól a szem, bár hallgat a száj, és beszéli, belől mi fáj. - Kazinczy Ferenc", // 25.
                "A hűség súlya alatt megroppanhat az, akinek gyenge a támasza. - Spartacus: Vér és homok",
                "Ne vitasd más emberek gyengeségeit és a sajátodat sem! Ha hibázol, ismerd be, javítsd ki és tanulj belőle - azonnal! - Stephen R. Covey",
                "Nehéz helyzeteken olykor átsegíthet egy-egy illúzió - érzés vagy hit -, de utána ki kell fizetned az árát - súlyos csalódásokban. Mindig próbáld kiszámolni, hogy megéri-e. - Moldova György",
                "A titkok nem arra valók, hogy az ember kifecsegje őket. - Lorraine Heath",
                "Még a szánakozást is lehetetlenné teszi az aljasság ezen a világon. - Thoman Mann", // 30
                "Ha valamit nem szabad, rögvest megnő a kereslet iránta. - Hendrik Groen",
                "Az ördögnek nem nyújthatjuk a kisujjunkat úgy, hogy el ne kapja az egész kezünket, sőt az egész embert. - Thomas Mann",
                "Az ember abban a pillanatban válik bűnössé, amikor rajtakapják. - John Vermeulen",
                "Egyedül azok szeghetik meg büntetlenül a törvényt, akik megalkották. - John Vermeulen",
                "A háború oka a földrajz - a politikai földrajz. Semmi egyéb. - Terence Hanbury White", // 35
                "A legjobb védekezés a támadás. - Bonaparte Napoleon",
                "Szórakozásból senki sem háborúzik. - Victor Máté",
                "Ha a világ beteg, forradalomra van szüksége, hasonlóan ahhoz, hogy amikor a test beteg, a gyulladás segíthet. - Jü Hua",
                "Könnyebb egy háborút elkezdeni, mint befejezni. - Gabriel García Márquez",
                "Soha ne hidd, hogy egy csata megnyerése az egész háború végét jelenti! - Susanna Tamaro", // 40
                "Csak a halott látja a háború végét. - Platón",
                "Nem mi vetünk véget a háborúnak, a háború fog végezni velünk. - Herbert George Wells",
                "Minden hadviselés megtévesztésen alapszik. - Szun-Ce",
                "A legyőzhetetlenség rajtunk múlik, a legyőzhetőség viszont az ellenségen. - Szun-Ce",
                "Minden háború az első csata előtti utolsó pillanatban dől el. - Szun-Ce", // 45
                "Jó csali alatt mindig van horogra akadt hal. - Szun-Ce",
                "Amikor a héja lecsap, és áldozata testét kettéroppantja, legfontosabb az időzítés. - Szun-Ce",
                "Nem az az igazán ügyes, aki száz csatában győz, hanem az, aki harc nélkül vesz erőt az ellenségen. - Szun-Ce",
                "A győzelem legfőbb feltétele az előzetes tudás, amely érdekében titkos ügynököket kell alkalmazni. - Szun-Ce",
                "El kell hagyni azt a helyet, ahol gyors támadás várható, s gyorsan le kell csapni ott, ahol éppen nem várják. - Szun-Ce", // 50
                "Azok, akik az ellenséges hadsereget – harc nélkül is – cselekvésképtelen helyzetbe hozzák, azok a valóban kiválóak. - Szun-Ce"
            };
            Random rnd = new Random();
            lb_excerpt.Text = quote[rnd.Next(quote.Count)];
            #endregion
        }

        void design(int backcolor0, int backcolor1, int backcolor2, int forecolor0, int forecolor1, int forecolor2)
        {
            // form háttér:
            this.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            // logó:
            lb_logo1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_logo2.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_logo1.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            lb_logo2.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            panel4.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            // verzió:
            lb_version.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_version.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            // aktuális kör:
            label10.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_round.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label5.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label10.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            lb_round.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            label5.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            panel1.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            // admin gomb:
            bt_admin.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            bt_admin.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            // általános adatok:
            label21.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // címke
            label20.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // teljes népesség
            label16.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // születésszám
            label24.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // halálozás
            label33.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // változás
            label35.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // elválasztócsík
            label13.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // terület
            label11.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // techkor
            label6.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2); // mezőgazdaság teljesítmény
            //
            label21.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2); // címke
            label20.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2); // teljes népesség
            label16.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2); // születésszám
            label24.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2); // halálozás
            label33.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2); // változás
            label35.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2); // elválasztócsík
            label13.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2); // terület
            label11.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2); // techkor
            label6.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2); // mezőgazdaság teljesítmény

            // általános adatok értékei:
            lb_population_total.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_born.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_mortality.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_popchange.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_area.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_tech_age.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_agro_volumen.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            //
            lb_population_total.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            lb_born.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            lb_mortality.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            lb_popchange.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            lb_area.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            lb_tech_age.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            lb_agro_volumen.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);

            // általános adatok panel beállítás
            panel3.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            // országnév:
            lb_country_name.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_country_name.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            panel5.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            // idézet:
            lb_excerpt.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_excerpt.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            panel6.Size = new Size(285, 111);
            panel6.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            // üzenet:
            lb_messages.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            lb_messages.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            panel8.Size = new Size(285, 50);
            panel8.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);

            // játékismertető:
            label1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            label1.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            textBox1.ForeColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);
            textBox1.BackColor = Color.FromArgb(backcolor0, backcolor1, backcolor2);
            panel7.Location = new Point(622, 13);
            panel7.BackColor = Color.FromArgb(forecolor0, forecolor1, forecolor2);


        }
    }
}
