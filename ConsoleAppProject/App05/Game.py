import pygame
import random

pygame.init()

HEIGHT = 600
WIDTH = 1000

screen = pygame.display.set_mode([WIDTH, HEIGHT])

pygame.display.set_caption('Game')
font = pygame.font.Font('freesansbold.ttf', 20)

fps = 60
timer = pygame.time.Clock()

newMap = True
mapRectangles = []
rectangleWidth = 5
rectangleTotal = WIDTH//rectangleWidth
padding = 15

playerX = 100
playerY = 300

flying = False
playerSpeedY = 0
gravity = 0.3

def generateNew():
    global playerY
    rectangles =[]
    topHeight = random.randint(0,300)
    playerY = topHeight + 150

    for i in range(rectangleTotal):
        topHeight = random.randint(topHeight - padding, topHeight + padding)
        if topHeight < 0:       # if padding takes the square off the screen
            topHeight = 0
        elif topHeight > 300:   # if padding takes the square off the screen
            topHeight = 300
        rectangleTop = pygame.draw.rect(screen, 'purple', [i * rectangleWidth, 0, rectangleWidth, topHeight])
        rectangleBottom = pygame.draw.rect(screen, 'purple', [i * rectangleWidth, topHeight + 300, rectangleWidth, HEIGHT])
        rectangles.append(rectangleTop)
        rectangles.append(rectangleBottom)
    return rectangles

def drawMap(rectangles):
    for i in range(len(rectangles)):
        pygame.draw.rect(screen, 'purple', rectangles[i])
    pygame.draw.rect(screen, 'dark gray', [0, 0, WIDTH, HEIGHT], 12)

def drawPlayer():
    # draw player hitbox and image
    player = pygame.draw.circle(screen, 'white', (playerX, playerY), 20)
    return player

def movePlayer(playerY, speed, flying):
    if flying:
        speed += gravity
    else:
        speed -= gravity

    playerY -= speed

    return playerY, speed

run = True

while run:
    screen.fill('black')
    timer.tick(fps)

    if newMap:
        mapRectangles = generateNew()
        newMap = False

    drawMap(mapRectangles)
    player = drawPlayer()
    playerY, playerSpeedY = movePlayer(playerY, playerSpeedY, flying)

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            run = False
        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_SPACE:
                flying = True
        if event.type == pygame.KEYUP:
            if event.key == pygame.K_SPACE:
                flying = False

    pygame.display.flip()

pygame.quit()