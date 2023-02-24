using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanSo
{
    class Chinh
    {
        static void Main(string[] agrs)
        {
            PhanSo a = new PhanSo();
            a.Nhap(3,0);
            Console.Write("Phan so a= ");
            a.Xuat();
            PhanSo b= new PhanSo();
            b.Nhap(-5,7);
            Console.Write("Phan so b= ");
            b.Xuat();

            //Tổng phân số 
            PhanSo tong= a.TinhTongPS(b);
            Console.Write("Tong Phan so a+b= ");
            tong.Xuat();

            //Tích Phân số
            PhanSo tich = a.TinhTichPS(b);
            Console.Write("Tich Phan so a*b= ");
            tich.Xuat();

            //Hiệu Phân số
            PhanSo hieu = a.TinhHieuPS(b);
            Console.Write("Hieu Phan so a+b= ");
            hieu.Xuat();
        }
    }
    class PhanSo
    {
        private int iTuSo;
        private int iMauSo;
        
        public int TuSo
        {
            get { return this.iTuSo; }
            set { this.iTuSo = value; }
        }
        public int MauSo
        {
            get { return this.iMauSo; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException(
                         $"{nameof(value)} phai khac 0 ");
                }                    
                this.iMauSo = value;
                
            }
        }
        public PhanSo()
        {
        }

        public PhanSo(int tu, int mau)
        {
            this.TuSo = tu;
            this.MauSo = mau;
        }

        ~PhanSo()
        {
        }

        public void Nhap()
        {
            Console.Write("Nhap tu so: ");
            this.TuSo = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau so: ");
            this.MauSo = int.Parse(Console.ReadLine());
            this.ToiGian();

        }
        public void Nhap(int tu, int mau)
        {
            this.TuSo = tu;
            this.MauSo = mau;
        }

        public void Xuat()
        {
            Console.WriteLine( this.iTuSo + "/" + this.iMauSo);
        }

        public void ToiGian()
        {
            if(this.iTuSo==0)
            {
                this.iMauSo = 1;
                return;
            }
            if (this.iMauSo < 0)
            {
                this.iTuSo = -this.iTuSo;
                this.iMauSo = -this.iMauSo;
            }
            int t = 1;
            if (this.iTuSo < 0)
            {
                this.iTuSo=-this.iTuSo;
                t = -1;
            }

            int u = UCLN(this.iTuSo, this.iMauSo);
            this.iTuSo = this.iTuSo / u * t;
            this.iMauSo = this.iMauSo / u;
        }

        public int UCLN(int x, int y)
        {
            for(int i=x; i>=2; i--)
                if(x%i==0 && y%i==0)
                    return i;
            return 1;
        }

        public PhanSo TinhTongPS( PhanSo b) 
        {
            PhanSo kq= new PhanSo();
            kq.TuSo = this.iTuSo * b.MauSo + b.TuSo * this.iMauSo;
            kq.MauSo = this.iMauSo * b.MauSo;
            kq.ToiGian();
            return kq;
        }

        public PhanSo TinhTichPS(PhanSo b)
        {
            PhanSo kq = new PhanSo();
            kq.TuSo = this.iTuSo * b.TuSo;
            kq.MauSo = this.iMauSo * b.MauSo;
            kq.ToiGian();
            return kq;
        }

        public PhanSo TinhHieuPS( PhanSo b)
        {
            PhanSo kq = new PhanSo();
            b.TuSo = -b.TuSo;
            kq.TuSo = this.iTuSo * b.MauSo + b.TuSo * this.iMauSo;
            kq.MauSo = this.iMauSo * b.MauSo;
            kq.ToiGian();
            return kq;
        }
    }
}
