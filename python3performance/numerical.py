import random
import numpy as np

def loop_approach(orders):
    result = 0
    for o in orders:
        result += o * o
    return result

# numpy is faster than the loop approach    
def numpy_approach(orders):
    numpy_orders = np.array(orders)
    return np.sum(numpy_orders * numpy_orders)

@profile
def main():
    orders = [random.randint(0, 100) for _ in range(100_000)]
    loop_approach(orders)
    numpy_approach(orders)    
    
main()

# First, to profile the numerical.py file, use the following command:
# kernprof -lv numerical.py

