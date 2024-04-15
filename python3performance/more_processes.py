from multiprocessing import Process


def clean_order():
    for _ in range(500_000_000):
        pass
    print('Finished cleaning')

if __name__ == '__main__':
    p1 = Process(target=clean_order)
    p2 = Process(target=clean_order)

    p1.start()
    p2.start()

    p1.join()
    p2.join()
