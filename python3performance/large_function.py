import time
import line_profiler

profile = line_profiler.LineProfiler()

@profile
def heavy_work():
    print('Do Something')
    print('Do Something')
    print('Do Something')

    for _ in range(100_000_000):
        pass

print('Do Something')
print('Do Something')

start_time = time.time()
heavy_work()
end_time = time.time()
print(f'Duration: {end_time - start_time}')
