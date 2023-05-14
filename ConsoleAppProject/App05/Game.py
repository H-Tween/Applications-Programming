import pygame

pygame.init()

HEIGHT = 600
WIDTH = 1000

screen = pygame.display.set_mode([WIDTH, HEIGHT])

pygame.display.set_caption('Game')
font = pygame.font.Font('freesansbold.ttf', 20)

fps = 60
timer = pygame.time.Clock()

run = True

while run:
    screen.fill('black')
    timer.tick(fps)

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            run = False

    pygame.display.flip()

pygame.quit()