//ATTEMPTING SIEVE OF ZAKIYA IMPLEMENTATION WITH A CODE SKELETON PROVIDED TO ME

int modpg = 30;
int rescnt = 8;
int[] residues = { 7, 11, 13, 17, 19, 23, 29, 31 };
int[] posn = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 3, 0, 4, 0, 0, 0, 5, 0, 0, 0, 0, 0, 6, 0, 7 };
int n = 544;     // input must be >= 7
//int val = (n - 1) | 1;  // ensure input odd number  //I'm not sure why though
Console.WriteLine("n: " + n);// + " val: " + val);
int kmax = n / modpg; //(val - 2) / modpg;  // the residue group val is in  
int r = 7;
Console.WriteLine("starting checks at: " + (modpg * kmax + residues[r]));
while ((modpg * kmax + residues[r]) > n) { r--; if (r == -1) break;} //for input such as 544 which resides between [tracks containing] 541 and 547, must have check to avoid -1 for array bounds protection
int maxpcs = kmax * rescnt + (r+1);     // number of prime candidates <= val
Console.WriteLine("maxpcs: " + maxpcs + " kmax: " + kmax + " r: " + r);
bool[] prms = new bool[maxpcs];  // want initialized to false
int k = 0; r = -1;

// mark the prime multiples
for (int i = 0; i < maxpcs; i++)
{
    r++; if (r == rescnt) { r = 0; k += 1; }//(r = 0, k += 1);
    if (prms[i]) continue;   // skip location if not prime
    int prm_r = residues[r];
    int prime = modpg * k + prm_r;
    if (prime > Math.Floor(Math.Sqrt(n))) break;//if (prime > Math.sqrt(val).floor) break;
    int primestep = prime * rescnt;
    for (int j = 0; j < rescnt; j++)
    {  // do for each residue
        int prod = prm_r * residues[j] - 2;
        int kpm = (k * (prime * residues[j]) + prod / modpg) * rescnt + posn[prod % modpg];
        while (kpm < maxpcs) { prms[kpm] = true; kpm += primestep; }  // set prms[kpm] to not-prime bool
    }
}
// extract prime value from prms array
r = -1;
for (int m = 0; m < maxpcs; m++)
{
    // iterate over each prms location
    r++; if (r == rescnt) { r = 0; k += 1; }//(r = 0, k += 1);
    Console.WriteLine("m: " + m + " chk: " + (modpg * k + residues[r]) + " modk: " + (modpg*k) + " residues[r]: " + residues[r] + " prms[m]: " + prms[m]);
    if (!prms[m])
    {  // check for what logic a prime value is
        int prime = modpg * k + residues[r];
        //Console.WriteLine(prime);
    }
}