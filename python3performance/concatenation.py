import random


@profile
def main():
    orders = [str(random.randint(0, 100)) for _ in range(50_000)]

    report = ''
    for o in orders:
        report += o
    
    # the .join() method is faster than the + operator
    ''.join(orders)

main()

# To profile each line on the concatenation.py file, use the following command:
# kernprof -lv concatenation.py

# To measure the memory usage, use the following command:
# python -m memory_profiler concatenation.py