import pygame
from hero import Hero
from wraith import Wraith
from reaper import Reaper
from scarecrow import Scarecrow
from graveyard.tile_block import Tile_block
from graveyard.grave_object import Grave_object

import random


class Playground:
    def __init__(self):
        """
        Constructor
        """

        # vytvoření herních prvků
        self.width = 1920
        self.height = 1080
        self.background = pygame.image.load('background/PNG/2_game_background/2_game_background.png')
        self.crate_width = 0
        self.ground_block_y = 0
        self.ground_block_x_left = 0
        self.ground_block_x_right = 0
        self.playground = self.create_playground()
        self.hero = self.create_hero()
        self.wraith = self.create_wraith()
        self.scarecrow = self.create_scarecrow()
        self.reaper = self.create_reaper()

        # stav hrdiny
        self.isJump = False
        self.isFall = False
        self.isDead = False

        # skoky
        self.jumpCount = 10
        self.fallFrequency = 5

        self.islandEnd = 0

    def create_playground(self):
        """
        Generates the playground with the tiles and graveyard objects
        """
        my_playground = []

        my_playground.append(Tile_block(0, self.height - 100, 0))  # Ground
        my_playground.append(Tile_block(450, 600, 3))  # Island with dead bushes
        my_playground.append(Tile_block(0, 450, 2))  # I sland on the left
        my_playground.append(Tile_block(500, 300, 6))  # Island in the middle
        my_playground.append(Tile_block(1280, 350, 4))  # Island on the right (top)
        my_playground.append(Tile_block(800, 700, 3))  # Island on the right (middle)

        # Graveyard objects - trees, tombstones, sign arrows, bushes, bones
        my_playground.append(Grave_object(800, 215, 8))
        my_playground.append(Grave_object(500, 65, 9))
        my_playground.append(Grave_object(900, 65, 9))
        my_playground.append(Grave_object(1200, 120, 9))
        my_playground.append(Grave_object(1620, 120, 9))
        my_playground.append(Grave_object(1450, 280, 11))
        my_playground.append(Grave_object(1550, 280, 11))
        my_playground.append(Grave_object(1650, 280, 11))
        my_playground.append(Grave_object(1170, self.height - 205, 13))
        my_playground.append(Grave_object(1400, 800, 1))
        my_playground.append(Grave_object(1350, 900, 3))
        my_playground.append(Grave_object(200, 890, 8))
        my_playground.append(Grave_object(100, 370, 5))
        my_playground.append(Grave_object(10, 410, 14))
        my_playground.append(Grave_object(500, self.height - 160, 6))
        my_playground.append(Grave_object(700, self.height - 160, 6))
        my_playground.append(Grave_object(550, self.height - 180, 5))
        my_playground.append(Grave_object(1400, self.height - 590, 9))
        my_playground.append(Grave_object(1300, self.height - 420, 7))
        my_playground.append(Grave_object(1450, self.height - 405, 10))
        my_playground.append(Grave_object(1700, self.height - 205, 13))
        my_playground.append(Grave_object(550, self.height - 570, 12))
        my_playground.append(Grave_object(600, self.height - 550, 7))
        my_playground.append(Grave_object(450, self.height - 550, 7))

        for my_obj in my_playground:
            if my_obj.type == 'crate':
                self.crate_width = my_obj.img.get_width()

        block_x = []
        block_width = 0

        for my_obj in my_playground:
            if my_obj.type == 'tile_block':
                for block in my_obj.block:
                    if self.ground_block_y != 0 and block.y != self.ground_block_y:
                        self.ground_block_y = block.y
                        break
                    else:
                        self.ground_block_y = block.y
            break

        for my_obj in my_playground:
            if my_obj.type == 'tile_block':
                for block in my_obj.block:
                    if block.y == self.ground_block_y:
                        block_x.append(block.x)
                        if block_width == 0:
                            block_width = block.img.get_width()

        self.ground_block_x_left = min(block_x)
        self.ground_block_x_right = max(block_x) + block_width
        return my_playground

    def show_playground(self, game_display):
        """
        Display plaground
        @param game_display: gpygame.display
        """
        for my_obj in self.playground:
            my_obj.show(game_display)

    def create_hero(self):
        hero_height = pygame.image.load('hero/Idle/0_Warrior_Idle Blinking_000.png').get_width()
        hero_down_offset = 40
        my_hero = Hero(self.width, self.height, 50, 50, hero_down_offset, True, 'Idle', 1, 100, 1, 900,
                       self.height - 100 - hero_height + hero_down_offset)
        return my_hero

    def show_hero(self, game_display):
        self.hero.show(game_display)

    def create_wraith(self):
        my_wraith = []
        wraith_height = pygame.image.load('enemy_wraith_2/Idle/Wraith_02_Idle Blinking_000.png').get_height()
        wraith_down_offset = 35
        wraith_direction = random.choice([True, False])
        if not wraith_direction:
            action = 'Walking'
        else:
            action = 'Walking_left'
        my_wraith.append(
            Wraith(self.width, self.height, 50, 50, wraith_down_offset, wraith_direction, action, 0, 50, 2, 200,
                   self.height - 100 - wraith_height + wraith_down_offset))
        my_wraith.append(
            Wraith(self.width, self.height, 50, 50, wraith_down_offset, wraith_direction, action, 0, 50, 3, 100,
                   450 - wraith_height + wraith_down_offset))
        return my_wraith

    def show_wraith(self, game_display):
        for my_obj in self.wraith:
            my_obj.show(game_display)

    def move_wraith(self):
        ground_block_center = (self.ground_block_x_right + self.ground_block_x_left) / 2
        for my_obj in self.wraith:
            if not my_obj.action == 'Walking' and not my_obj.action == 'Walking_left':
                continue
            if abs(ground_block_center - (my_obj.x + (my_obj.get_width() / 2))) < (
                            ground_block_center - self.ground_block_x_left + my_obj.right_offset):
                my_obj.direction = not my_obj.direction
                if my_obj.action == 'Walking':
                    my_obj.action = 'Walking_left'
                else:
                    my_obj.action = 'Walking'
            for my_tile_block in self.playground:
                if my_tile_block.type == 'tile_block' and \
                        my_obj.y == (my_tile_block.y - my_obj.get_height() + my_obj.down_offset) and \
                        ((my_obj.x + my_obj.left_offset <= my_tile_block.x) or (
                                my_obj.x + my_obj.get_width() - my_obj.right_offset >= my_tile_block.x + my_tile_block.get_width())):
                    my_obj.direction = not my_obj.direction
                    if my_obj.action == 'Walking':
                        my_obj.action = 'Walking_left'
                    else:
                        my_obj.action = 'Walking'

            if my_obj.direction:
                my_obj.x -= 5
            if not my_obj.direction:
                my_obj.x += 5

    def create_scarecrow(self):
        scarecrow_height = pygame.image.load('scarecrow/Idle/std_0.png').get_height()
        scarecrow_down_offset = 35
        scarecrow_direction = random.choice([True, False])
        if not scarecrow_direction:
            action = 'Walking'
        else:
            action = 'Walking_left'
        my_scarecrow = Scarecrow(self.width, self.height, 50, 50, scarecrow_down_offset, scarecrow_direction, action, 1,
                                 100, 1, 1350,
                                 self.height - 100 - 250 - scarecrow_height + scarecrow_down_offset)
        return my_scarecrow

    def show_scarecrow(self, game_display):
        self.scarecrow.show(game_display)

    def move_scarecrow(self):
        if not self.scarecrow.action == 'Walking' and not self.scarecrow.action == 'Walking_left':
            pass
        else:
            if self.scarecrow.x + (self.scarecrow.get_width() / 2) < self.ground_block_x_left or self.scarecrow.x + (self.scarecrow.get_width() / 2) > self.ground_block_x_right:
                self.scarecrow.direction = not self.scarecrow.direction
                self.scarecrow.action = 'Rotating'
                self.scarecrow.image_id = 0

            if self.scarecrow.direction:
                self.scarecrow.x -= 5
            else:
                self.scarecrow.x += 5

    def create_reaper(self):
        reaper_height = pygame.image.load('reaper_3/Idle/0_Reaper_Man_Idle Blinking_000.png').get_height()
        reaper_down_offset = 35
        scarecrow_direction = random.choice([True, False])
        if not scarecrow_direction:
            action = 'Walking'
        else:
            action = 'Walking_left'
        my_reaper = Reaper(self.width, self.height, 50, 50, reaper_down_offset, scarecrow_direction, action, 1, 50, 1,
                           1500,
                           350 - reaper_height + reaper_down_offset)
        return my_reaper

    def show_reaper(self, game_display):
        self.reaper.show(game_display)

    def move_reaper(self):
        if not self.reaper.action == 'Walking' and not self.reaper.action == 'Walking_left' \
                and not self.reaper.action == 'Running' and not self.reaper.action == 'Running_left':
            pass
        else:
            for my_tile_block in self.playground:
                if my_tile_block.type == 'tile_block' \
                        and self.reaper.y == (my_tile_block.y - self.reaper.get_height() + self.reaper.down_offset) and \
                        ((self.reaper.x + self.reaper.left_offset == my_tile_block.x and self.reaper.action != 'Walking') or
                         self.reaper.x + self.reaper.get_width() - self.reaper.right_offset >= my_tile_block.x + my_tile_block.get_width()):
                    self.reaper.direction = not self.reaper.direction
                    self.islandEnd = my_tile_block.x
                    if self.reaper.action == 'Walking':
                        self.reaper.action = 'Walking_left'
                    else:
                        self.reaper.action = 'Walking'
            if self.reaper.direction:
                if self.reaper.action == 'Walking_left':
                    self.reaper.x -= 5
                elif self.reaper.action == 'Running_left':
                    self.reaper.x -= 10
            else:
                if self.reaper.action == 'Walking':
                    self.reaper.x += 5
                elif self.reaper.action == 'Running':
                    self.reaper.x += 10

            if self.reaper.action == 'Running_left' and (self.reaper.x + self.reaper.left_offset < self.islandEnd):
                self.reaper.x = self.islandEnd - self.reaper.left_offset

    def run(self, enemy_types):
        """
        Main loop of the application
        @param enemy_types:
        """
        clock = pygame.time.Clock()
        pygame.init()
        game_display = pygame.display.set_mode((self.width, self.height))
        pygame.display.set_caption('Halloween Party')

        while True:
            for event in pygame.event.get():
                if event.type == pygame.QUIT:
                    pygame.quit()
                    quit()

            # reakce na uživatelův vstup (tlačítka klávesnice)
            if not self.isDead:
                self.hero.action = 'Idle'
                keys_pressed = pygame.key.get_pressed()
                if keys_pressed[pygame.K_LEFT] and self.hero.x + self.hero.left_offset > 0:
                    self.hero.x -= 10
                    self.hero.action = 'Walking'
                    if self.hero.image_id > 14:
                        self.hero.image_id = 0
                if keys_pressed[pygame.K_RIGHT] \
                        and self.hero.x + self.hero.get_width() - self.hero.right_offset < self.width:
                    self.hero.x += 10
                    self.hero.action = 'Walking'
                    if self.hero.image_id > 14:
                        self.hero.image_id = 0
                if keys_pressed[pygame.K_UP] and not self.isJump and not self.isFall:
                    self.isJump = True
                    self.hero.action = 'Walking'
                    if self.hero.image_id > 14:
                        self.hero.image_id = 0
                if keys_pressed[pygame.K_SPACE] and not self.isJump and not self.isFall:
                    self.hero.action = 'Attacking'
                    if self.hero.image_id > 14:
                        self.hero.image_id = 0

            game_display.blit(self.background, [0, 0])
            self.show_playground(game_display)

            self.show_hero(game_display)
            self.isFall = True

            self.show_wraith(game_display)
            self.move_wraith()

            self.show_scarecrow(game_display)
            self.move_scarecrow()

            self.show_reaper(game_display)
            self.move_reaper()

            # skok hrdiny
            if self.isJump:
                if self.jumpCount >= -10:
                    self.hero.y -= (self.jumpCount * abs(self.jumpCount)) * 0.75
                    self.jumpCount -= 1
                else:
                    self.jumpCount = 10
                    self.isJump = False

            # pád hrdiny na zem
            if self.hero.y >= (self.height - 100 - self.hero.get_height() + self.hero.down_offset):
                self.isFall = False
                self.fallFrequency = 5
                self.hero.y = self.height - 100 - self.hero.get_height() + self.hero.down_offset

            for my_obj in self.playground:

                # stopunutí hrdiny na boxy
                if my_obj.type == 'crate' and \
                        (abs(my_obj.y - self.hero.y - self.hero.get_height() + self.hero.down_offset) < 40) and \
                        abs((my_obj.x + (self.crate_width / 2)) - (self.hero.x + (self.hero.get_width() / 2))) < (
                        self.crate_width / 2):
                    self.hero.y = my_obj.y - self.hero.get_height() + self.hero.down_offset
                    self.jumpCount = 10
                    self.isJump = False
                    self.isFall = False
                    self.fallFrequency = 5

                # stoupnutí hrdiny na ostrovy
                if my_obj.type == 'tile_block' and \
                        (abs(my_obj.y - self.hero.y - self.hero.get_height() + self.hero.down_offset) < 40) and \
                        abs((my_obj.x + (my_obj.get_width() / 2)) - (self.hero.x + (self.hero.get_width() / 2))) < (
                        my_obj.get_width() / 2):
                    self.hero.y = my_obj.y - self.hero.get_height() + self.hero.down_offset
                    self.jumpCount = 10
                    self.isJump = False
                    self.isFall = False
                    self.fallFrequency = 5

            ground_block_center = (self.ground_block_x_right + self.ground_block_x_left) / 2
            # stoupnutí hrdiny na kus země mezi 2 boxy
            if abs(ground_block_center - (self.hero.x + (self.hero.get_width() / 2))) < (ground_block_center - self.ground_block_x_left) and\
                    abs(self.ground_block_y - self.hero.get_height() - (self.hero.down_offset * 2) - 5 - self.hero.y) < self.hero.down_offset / 2:
                self.isFall = False
                self.fallFrequency = 5
                self.jumpCount = 10
                self.isJump = False
                self.hero.y = self.ground_block_y - self.hero.get_height() - (self.hero.down_offset * 2) - 5

            # zabráni vstupu hrdiny do země mezi 2 boxy
            if abs(ground_block_center - (self.hero.x + (self.hero.get_width() / 2))) < (ground_block_center - self.ground_block_x_left + self.hero.right_offset) and self.hero.y > self.ground_block_y - self.hero.get_height():
                if self.hero.x < ground_block_center:
                    self.hero.x = self.ground_block_x_left - (self.hero.get_width() / 2) - self.hero.left_offset
                else:
                    self.hero.x = self.ground_block_x_right - (self.hero.get_width() / 2) + self.hero.left_offset

            # pád hrdiny, rychlost pádu se postupně zvyšuje
            if self.isFall:
                self.hero.y += self.fallFrequency
                self.fallFrequency += 0.75

            # útok wraithů na hrdinu
            for my_obj in self.wraith:
                isWraithAttacking = False
                if (self.isDead and (
                        my_obj.action == 'Walking' or my_obj.action == 'Walking_left')) or my_obj.health <= 0:
                    continue
                if (my_obj.y + my_obj.get_height() - my_obj.down_offset) == (
                        self.hero.y + self.hero.get_height() - self.hero.down_offset):
                    if (my_obj.x > self.hero.x) and (
                            my_obj.x - self.hero.x < self.hero.get_width() - self.hero.left_offset - self.hero.right_offset):
                        my_obj.action = 'Attacking_left'
                        isWraithAttacking = True
                        self.hero.action = 'Hurt'
                        self.hero.health -= 1
                    if (my_obj.x < self.hero.x) and (
                            self.hero.x - my_obj.x < self.hero.get_width() - self.hero.left_offset - self.hero.right_offset):
                        my_obj.action = 'Attacking'
                        isWraithAttacking = True
                        self.hero.action = 'Hurt'
                        self.hero.health -= 1
                if (my_obj.action == 'Attacking' or my_obj.action == 'Attacking_left') and (
                        not isWraithAttacking or self.isDead):
                    wraith_direction = my_obj.direction
                    if not wraith_direction:
                        my_obj.action = 'Walking'
                        my_obj.direction = wraith_direction
                    else:
                        my_obj.action = 'Walking_left'
                        my_obj.direction = wraith_direction

            # útok hrdiny na wraithy
            for my_obj in self.wraith:
                isWraithAttacked = False
                if self.hero.action == 'Attacking' and my_obj.health > 0 and (
                        my_obj.y + my_obj.get_height() - my_obj.down_offset) == (
                        self.hero.y + self.hero.get_height() - self.hero.down_offset) and \
                        (abs(self.hero.x - my_obj.x) < (my_obj.get_width() - my_obj.right_offset)):
                    my_obj.action = 'Hurt'
                    my_obj.health -= 1
                    isWraithAttacked = True
                if my_obj.action == 'Hurt' and not isWraithAttacked:
                    wraith_direction = my_obj.direction
                    if not wraith_direction:
                        my_obj.action = 'Walking'
                        my_obj.direction = wraith_direction
                    else:
                        my_obj.action = 'Walking_left'
                        my_obj.direction = wraith_direction

            # útok scarecrowa na hrdinu
            isScarecrowAttacking = False
            if (abs(self.scarecrow.y - self.hero.y) < 50) and not self.isDead:
                if (self.scarecrow.x > self.hero.x) and (
                        self.scarecrow.x - self.hero.x < self.hero.get_width() - self.hero.left_offset - self.hero.right_offset):
                    self.scarecrow.action = 'Attacking_left'
                    isScarecrowAttacking = True
                    self.hero.action = 'Hurt'
                    self.hero.health -= 1
                if (self.scarecrow.x < self.hero.x) and (
                        self.hero.x - self.scarecrow.x < self.hero.get_width() - self.hero.left_offset - self.hero.right_offset):
                    self.scarecrow.action = 'Attacking'
                    isScarecrowAttacking = True
                    self.hero.action = 'Hurt'
                    self.hero.health -= 1
            if (self.scarecrow.action == 'Attacking' or self.scarecrow.action == 'Attacking_left') and (
                    not isScarecrowAttacking or self.isDead):
                wraith_direction = self.scarecrow.direction
                if not wraith_direction:
                    self.scarecrow.action = 'Walking'
                    self.scarecrow.direction = wraith_direction
                else:
                    self.scarecrow.action = 'Walking_left'
                    self.scarecrow.direction = wraith_direction

            # útok reapera na hrdinu
            isReaperAttacking = False
            if (self.isDead and (self.reaper.action == 'Walking' or self.reaper.action == 'Walking_left')) or self.reaper.health <= 0:
                pass
            else:
                if (self.reaper.y + self.reaper.get_height() - self.reaper.down_offset) == (
                        self.hero.y + self.hero.get_height() - self.hero.down_offset):
                    if (self.reaper.x > self.hero.x) and (
                            self.reaper.x - self.hero.x < self.hero.get_width() - self.hero.left_offset - self.hero.right_offset):
                        self.reaper.action = 'Attacking_left'
                        isReaperAttacking = True
                        self.hero.action = 'Hurt'
                        self.hero.health -= 1
                    if (self.reaper.x < self.hero.x) and (
                            self.hero.x - self.reaper.x < self.hero.get_width() - self.hero.left_offset - self.hero.right_offset):
                        self.reaper.action = 'Attacking'
                        isReaperAttacking = True
                        self.hero.action = 'Hurt'
                        self.hero.health -= 1
                if (self.reaper.action == 'Attacking' or self.reaper.action == 'Attacking_left') and (
                        not isReaperAttacking or self.isDead):
                    reaper_direction = self.reaper.direction
                    if not reaper_direction:
                        self.reaper.action = 'Walking'
                        self.reaper.direction = reaper_direction
                    else:
                        self.reaper.action = 'Walking_left'
                        self.reaper.direction = reaper_direction

            # útok hrdiny na reapera
            isReaperAttacked = False
            if self.hero.action == 'Attacking' and self.reaper.health > 0 and (
                    self.reaper.y + self.reaper.get_height() - self.reaper.down_offset) == (
                    self.hero.y + self.hero.get_height() - self.hero.down_offset) and \
                    (abs(self.hero.x - self.reaper.x) < (self.reaper.get_width() - self.reaper.right_offset)):
                self.reaper.action = 'Hurt'
                self.reaper.health -= 1
                isReaperAttacked = True
                if self.reaper.health <= 0:
                    self.reaper.image_id = 0
                    self.reaper.action = 'Dying'
            if self.reaper.action == 'Hurt' and not isReaperAttacked:
                reaper_direction = self.reaper.direction
                if not reaper_direction:
                    self.reaper.action = 'Walking'
                    self.reaper.direction = reaper_direction
                else:
                    self.reaper.action = 'Walking_left'
                    self.reaper.direction = reaper_direction

            for my_tile_block in self.playground:

                # idle reapera na rohu ostrovu
                if my_tile_block.type == 'tile_block' and (self.reaper.y == (my_tile_block.y - self.reaper.get_height() + self.reaper.down_offset)) \
                        and (self.hero.y < self.reaper.y) and (abs(self.reaper.x - self.hero.x) < 350) and (self.reaper.x + self.reaper.left_offset == my_tile_block.x):
                    self.reaper.action = 'Idle_left'

                # ukončení idle reapera na rohu ostrovu
                if my_tile_block.type == 'tile_block' and (self.reaper.y == (my_tile_block.y - self.reaper.get_height() + self.reaper.down_offset)) \
                        and self.reaper.action == 'Idle_left' and (self.reaper.x + self.reaper.left_offset == my_tile_block.x) and ((self.hero.y >= self.reaper.y) or (abs(self.reaper.x - self.hero.x) >= 350)):
                    self.reaper.action = 'Walking'
                    self.reaper.direction = False

            # běh reapera - doleva
            if self.hero.x < self.reaper.x and (abs(self.reaper.x - self.hero.x) < 500) and \
                    (self.hero.y - self.hero.down_offset) <= (self.reaper.y - self.reaper.down_offset) and self.reaper.action == 'Walking_left':
                self.reaper.action = 'Running_left'

            if self.reaper.action == 'Running_left' and not (self.hero.x < self.reaper.x and (abs(self.reaper.x - self.hero.x) < 500) and (self.hero.y - self.hero.down_offset) <= (self.reaper.y - self.reaper.down_offset)):
                self.reaper.action = 'Walking_left'

            # běh reapera - doprava
            if self.hero.x > self.reaper.x and (abs(self.hero.x - self.reaper.x) < 500) and \
                    (self.hero.y - self.hero.down_offset) <= (self.reaper.y - self.reaper.down_offset) and self.reaper.action == 'Walking':
                self.reaper.action = 'Running'

            if self.reaper.action == 'Running' and not (self.hero.x > self.reaper.x and (abs(self.hero.x - self.reaper.x) < 500) and (self.hero.y - self.hero.down_offset) <= (self.reaper.y - self.reaper.down_offset)):
                self.reaper.action = 'Walking'

            # smrt hrdiny
            if self.hero.health <= 0:
                self.isDead = True
                self.hero.action = 'Dying'

            # smrt wraitha
            for my_obj in self.wraith:
                if my_obj.health <= 0:
                    my_obj.action = 'Dying'

            # smrt reapera
            if self.reaper.health <= 0:
                self.reaper.action = 'Dying'

            # nastavení obrázku pro hrdinu
            self.hero.image_id += 1
            if self.hero.action == 'Idle' and self.hero.image_id >= 30:
                self.hero.image_id = 0
            if self.hero.action == 'Walking' and self.hero.image_id >= 15:
                self.hero.image_id = 0
            if self.hero.action == 'Hurt' and self.hero.image_id >= 15:
                self.hero.image_id = 0
                self.hero.action = 'Idle'
                self.hero.health -= 1
            if self.hero.action == 'Attacking' and self.hero.image_id >= 15:
                self.hero.image_id = 0
            if not (self.hero.action == 'Dying' and self.hero.image_id >= 30):
                self.hero.update_image(self.hero.image_id)

            # nastavení obrázku pro wraithy
            for my_obj in self.wraith:
                my_obj.image_id += 1
                if (my_obj.action == 'Walking' or my_obj.action == 'Walking_left' or my_obj.action == 'Attacking' or
                    my_obj.action == 'Attacking_left' or my_obj.action == 'Hurt') and my_obj.image_id >= 12:
                    my_obj.image_id = 0
                if not (my_obj.action == 'Dying' and my_obj.image_id >= 15):
                    my_obj.update_image()

            # nastavení obrázku pro scarecrowa
            self.scarecrow.image_id += 1
            if (self.scarecrow.action == 'Walking' or self.scarecrow.action == 'Walking_left' or
                self.scarecrow.action == 'Attacking' or self.scarecrow.action == 'Attacking_left') and self.scarecrow.image_id >= 30:
                self.scarecrow.image_id = 0
            if self.scarecrow.action == 'Rotating' and self.scarecrow.image_id >= 8:
                if self.scarecrow.direction:
                    self.scarecrow.action = 'Walking_left'
                else:
                    self.scarecrow.action = 'Walking'
            self.scarecrow.update_image()

            # nastavení obrázku pro reapera
            self.reaper.image_id += 1
            if (self.reaper.action == 'Walking' or self.reaper.action == 'Walking_left') and self.reaper.image_id >= 24:
                self.reaper.image_id = 0
            if (self.reaper.action == 'Attacking' or self.reaper.action == 'Attacking_left' or self.reaper.action == 'Hurt') and self.reaper.image_id >= 12:
                self.reaper.image_id = 0
            if (self.reaper.action == 'Idle' or self.reaper.action == 'Idle_left') and self.reaper.image_id >= 18:
                self.reaper.image_id = 0
            if (self.reaper.action == 'Running' or self.reaper.action == 'Running_left') and self.reaper.image_id >= 12:
                self.reaper.image_id = 0
            if not (self.reaper.action == 'Dying' and self.reaper.image_id >= 15):
                self.reaper.update_image()

            pygame.display.update()  # Update of the screen
            clock.tick(60)


if __name__ == '__main__':
    enemy_types = [3, 2, 4, 5]
    pg = Playground()
    pg.run(enemy_types)
