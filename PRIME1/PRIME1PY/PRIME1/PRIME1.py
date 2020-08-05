import math

def Mark2(b):
    arr = [False]*b
    res = (int(b/2)+2)*[0]
    for i in range(2, int(math.sqrt(b))+2):
        if(arr[i]==False):
            for j in range(i,int(b/i)):
                arr[i*j]=True
    
    res[0]=2
    cont = 1
    for u in range(3,b,2):
        if(arr[u]==False):
            res[cont]=u
            cont+=1
    
    primes = [0]*cont
    cont = 0
    while(res[cont] != 0):
        primes[cont] = res[cont]
        cont+=1

    return primes

def SegmentedMark2(M,N,primes):
    if(M<2):
        M=2
    
    size = N-M+1
    Range = [False]*size

    for i in range(0,len(primes)):
        for u in range(M,N+1):
            if(Range[u-M] == False):
                if(u%primes[i] == 0 and u!= primes[i]):
                    Range[u-M]=True
    
    for i in range(0,len(Range)):
        if(Range[i]== False):
            print(i+M)

t = int(input())
M = [0]*t
N = [0]*t

primes = Mark2(3200)

for i in range(0,t):
    case = input().split(' ')
    M[i]= int(case[0])
    N[i]= int(case[1])

for i in range(0,t):
    SegmentedMark2(M[i],N[i],primes)
    print('')
