using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Forms2
{
    public class Memory
    {
        public Memory(uint size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(size), $"{nameof(size)} не может быть отрицательным или равным 0");
            }
            PageAgePairs = new Dictionary<Page, uint>();
            for (uint i = 0; i < size; ++i)
            {
                PageAgePairs.Add(new Page(i), 0);
            }
        }

        public bool RequestPage(uint number, out Page removedPage)
        {
            bool isFault = false;
            Page page = PageAgePairs.SingleOrDefault(pair => pair.Key.Number == number).Key;
            removedPage = null;

            if (page is null)
            {
                isFault = true;
                removedPage = PageAgePairs.OrderByDescending(pair => pair.Value).First().Key;
                PageAgePairs.Remove(removedPage);
                page = new Page(number);
                PageAgePairs.Add(page, 0);
            }

            foreach (var key in PageAgePairs.Keys.ToList())
            {
                if (key != page)
                {
                    ++PageAgePairs[key];
                }
                else
                {
                    PageAgePairs[key] = 0;
                }
            }

            return isFault;
        }

        public Dictionary<Page, uint> PageAgePairs { get; }
    }
}
