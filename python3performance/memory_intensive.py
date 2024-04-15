@profile
def create_big_list():
    return 10_000_000 * [0]

@profile
def create_huge_list():
    return 30_000_000 * [0]

create_big_list()
create_huge_list()

