<?php
/**
 * @var \App\View\AppView $this
 * @var \App\Model\Entity\Shootingleveldesign $shootingleveldesign
 */
?>
<nav class="large-3 medium-4 columns" id="actions-sidebar">
    <ul class="side-nav">
        <li class="heading"><?= __('Actions') ?></li>
        <li><?= $this->Html->link(__('Edit Shootingleveldesign'), ['action' => 'edit', $shootingleveldesign->Number]) ?> </li>
        <li><?= $this->Form->postLink(__('Delete Shootingleveldesign'), ['action' => 'delete', $shootingleveldesign->Number], ['confirm' => __('Are you sure you want to delete # {0}?', $shootingleveldesign->Number)]) ?> </li>
        <li><?= $this->Html->link(__('List Shootingleveldesign'), ['action' => 'index']) ?> </li>
        <li><?= $this->Html->link(__('New Shootingleveldesign'), ['action' => 'add']) ?> </li>
    </ul>
</nav>
<div class="shootingleveldesign view large-9 medium-8 columns content">
    <h3><?= h($shootingleveldesign->Number) ?></h3>
    <table class="vertical-table">
        <tr>
            <th scope="row"><?= __('Number') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->Number) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('Level') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->Level) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('Pattern') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->Pattern) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('PosX') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->PosX) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('PosY') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->PosY) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('PosZ') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->PosZ) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('RateX') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->RateX) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('RateY') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->RateY) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('RateZ') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->RateZ) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('ScaleX') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->ScaleX) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('ScaleY') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->ScaleY) ?></td>
        </tr>
        <tr>
            <th scope="row"><?= __('ScaleZ') ?></th>
            <td><?= $this->Number->format($shootingleveldesign->ScaleZ) ?></td>
        </tr>
    </table>
</div>
