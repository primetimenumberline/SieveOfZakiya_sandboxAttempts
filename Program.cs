//ATTEMPTING SIEVE OF ZAKIYA IMPLEMENTATION WITH A CODE SKELETON PROVIDED TO ME

int modpg = 30;
int rescnt = 8;
int[] residues = { 7, 11, 13, 17, 19, 23, 29, 31 };
int[] posn = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 2, 0, 0, 0, 3, 0, 4, 0, 0, 0, 5, 0, 0, 0, 0, 0, 6, 0, 7 };
int n = 2201;//2213;//2219;//2221;//2227;//510;//2251;//547;     // input must be >= 7

Console.WriteLine("n: " + n);
int kmax = n / modpg;
int r = 7;

Console.WriteLine("starting checks at: " + (modpg * kmax + residues[r]) + " kmax: "+kmax + " kmax*rescnt: "+ (kmax*rescnt));

while ((modpg * kmax + residues[r]) > n) { r--; if (r == -1) break;} 
int maxpcs = kmax * rescnt + (r + 1);     // number of prime candidates <= val
if (modpg * kmax == n) maxpcs -= 1;     //remove the overcounting, which occurs at the boundary condition where n == modpg*kmax

Console.WriteLine("maxpcs: " + maxpcs + " r: " + r);

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
   // Console.WriteLine("prime: " + prime + " primestep: " + primestep);
    for (int j = 0; j < rescnt; j++)
    {  // do for each residue
        int prod = prm_r * residues[j] - 2;
        //Console.WriteLine("prod: " + prod);
        int kpm = (k * (prime * residues[j]) + prod / modpg) * rescnt + posn[prod % modpg];
        //Console.WriteLine("kpm: " + kpm + " prod/modpg: " + (prod/modpg) + "prod%modpg: "+(prod%modpg) +" posn[prod%modpg]: " + posn[prod%modpg]);
        while (kpm < maxpcs) {
            prms[kpm] = true;
            //Console.Write("prm[{0}], ", kpm);
            kpm += primestep;
            //Console.WriteLine("kpm "+kpm);
        }  // set prms[kpm] to not-prime bool
    }
}
// extract prime value from prms array
r = -1; k = 0;
for (int m = 0; m < maxpcs; m++)
{
    // iterate over each prms location
    r++; if (r == rescnt) { r = 0; k += 1; }//(r = 0, k += 1);
    Console.WriteLine("m: " + m + " chk: " + (modpg * k + residues[r]) +" k: " +k+" modk: " + (modpg*k) + " residues[r]: " + residues[r] + " prms[m]: " + prms[m]);
    if (!prms[m])
    {  // check for what logic a prime value is
        int prime = modpg * k + residues[r];
        //Console.WriteLine(prime);
    }
}