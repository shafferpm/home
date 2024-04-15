import threading
from time import sleep

def process_order(order_id):
    print(f'Processing order with id={order_id}')
    sleep(1)
    print(f'Finished processing order with id={order_id}')

first_thread = threading.Thread(target=process_order, args=(10,))
second_thread = threading.Thread(target=process_order, args=(20,))

first_thread.start()
second_thread.start()
