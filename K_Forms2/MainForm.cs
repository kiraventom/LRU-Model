using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Extensions.ControlExtensions;

namespace K_Forms2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Memory = new Memory(MemorySize);
            PageFaultsAmount = 0;
        }

        private const int MemorySize = 5;
        private const int PagesAmount = 16;
        private const string Separator = "-------------------------";
        private readonly Size ButtonSize = new Size(80, 80);
        private Memory Memory { get; }
        private int PageFaultsAmount { get; set; }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillPagesFLPWithButtons();
            UpdateMemoryFLP();
        }

        private void FillPagesFLPWithButtons()
        {
            PagesFLP.Controls.Remove(PagesMockBt);
            for (int i = 0; i < PagesAmount; ++i)
            {
                Button pageBt = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.Black,
                    BackgroundImage = Graphic.GetTileWithNumber(i, ButtonSize, Color.White, Graphic.GetRandomLightColor()),
                    BackgroundImageLayout = ImageLayout.Zoom,
                    Text = string.Empty,
                    Name = $"PageBt{i}",
                    Size = ButtonSize,
                    Tag = i
                };
                pageBt.Click += PageBt_Click;
                PagesFLP.Controls.Add(pageBt);
            }
            PagesFLP.Controls.Add(PagesMockBt);
        }

        private void PageBt_Click(object sender, EventArgs e)
        {
            if (sender is Button pageBt)
            {
                int logNextLineIndex = 0;
                LogLB.Items.Insert(logNextLineIndex++, $"Была запрошена страница {(int)pageBt.Tag}.");
                var isPageFault = Memory.RequestPage(uint.Parse(pageBt.Tag.ToString()), out Page removedPage);
                if (isPageFault)
                {
                    ++PageFaultsAmount;
                    Button removedPageBt = MemoryFLP.Controls.OfType<Button>().Where(b => b.Tag != null).Single(bt => (int)bt.Tag == removedPage.Number);
                    removedPageBt.Text = string.Empty;
                    removedPageBt.PerformPageBtAnimation(PagesMockBt, PagesFLP);
                    LogLB.Items.Insert(logNextLineIndex++, $"Была замещена страница {removedPage.Number}.");
                    LogLB.Items.Insert(logNextLineIndex++, $"Кол-во стр. прерываний - { PageFaultsAmount}");
                }
                LogLB.Items.Insert(logNextLineIndex++, Separator);
                this.Refresh();
                System.Threading.Thread.Sleep(100);

                if (pageBt.Parent == PagesFLP)
                    pageBt.PerformPageBtAnimation(MemoryMockBt, MemoryFLP);

                UpdateMemoryFLP();
            }
        }

        private void UpdateMemoryFLP()
        {
            foreach (var pair in Memory.PageAgePairs)
            {
                var button = MemoryFLP.Controls.OfType<Button>().Where(b => b.Tag != null).SingleOrDefault(bt => (int)bt.Tag == pair.Key.Number);
                if (button is null)
                {
                    button = PagesFLP.Controls.OfType<Button>().Where(b => b.Tag != null).Single(bt => (int)bt.Tag == pair.Key.Number);
                    button.PerformPageBtAnimation(MemoryMockBt, MemoryFLP);
                }
                button.Text = $"Возраст: {pair.Value}";
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Программа \"Замещение страниц\" демонстрирует модель алгоритма замещения страниц \"LRU\".\n\n" +
                "Исходные условия: размер памяти -- 5 страничных блоков, количество страниц -- 16.\n\n" +
                "Для запроса страницы нажмите на неё левой кнопкой мыши. В правой части окна программы ведётся журнал" +
                " происходящего в модели, в том числе ведётся подсчёт количества страничных прерываний.\n\n" +
                "СПБГТИ(ТУ), 474 группа, Темирканов А.З., 2019 г.",
                "Помощь",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
