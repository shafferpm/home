from dask.distributed import Client


def clean_order(order_id):
    for _ in range(500_000_000):
        pass
    print(f"Finished cleaning order with id={order_id}")


if __name__ == '__main__':
    client = Client()
    client.map(clean_order, [10, 20])    
    # first = Process(target=clean_order, args=(10,))
    # second = Process(target=clean_order, args=(20,))

    # first.start()
    # second.start()

    # first.join()
    # second.join()

# https://distributed.dask.org/en/stable/install.html
# python -m pip install dask distributed --upgrade
# time python hello_dask.py
