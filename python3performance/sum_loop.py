import time


def heavy_work():
    for _ in range(100_000_000):
        do_stuff()

def do_stuff():
    return 1+2    

start_time = time.time()
heavy_work()
end_time = time.time()
print(f'Duration: {end_time - start_time: .2f} seconds')
