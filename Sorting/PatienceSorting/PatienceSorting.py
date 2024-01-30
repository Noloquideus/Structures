def patience_sort(arr):
    piles = []  # Стопки
    for num in arr:
        placed = False
        for pile in piles:
            if pile[-1] >= num:
                pile.append(num)
                placed = True
                break
        if not placed:
            piles.append([num])

    # Слияние стопок
    result = []
    while piles:
        min_pile_index = min(range(len(piles)), key=lambda i: piles[i][-1])
        min_pile = piles[min_pile_index]
        result.append(min_pile.pop())
        if not min_pile:
            piles.pop(min_pile_index)

    return result
