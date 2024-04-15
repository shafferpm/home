import numpy

def double_list(size):
    initial_list = list(range(size))
    return [2 * i for i in initial_list]

def double_array(size):
    initial_array = numpy.arange(size)
    return 2 * initial_array

double_list(1_000_000)
double_array(1_000_000)

# this creates the list_array.prof file
# python -m cProfile -o list_array.prof list_array.py
